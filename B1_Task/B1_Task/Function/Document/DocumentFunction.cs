using System;
using System.IO;
using System.Text;
using B1_Task.Controllers.ProcessHub;
using B1_Task.Entity;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace B1_Task.Function.Document
{
    public class DocumentFunction : IDocumentFunction
    {
        private readonly B1Context _b1Context;
        private readonly IHubContext<ProcessHub> _processHub;

        public DocumentFunction(B1Context b1Context, IHubContext<ProcessHub> processHub)
        {
            _b1Context = b1Context;
            _processHub = processHub;
        }

        public int CreateCommonDoc(string path, string stringToRemove)
        {
            using (var output = File.Open(Path.Combine(path, "output.txt"), FileMode.Create))
            {
                var totalDeletedLines = 0;

                foreach (var fileName in CreateListDocuments())
                {
                    string filePath = Path.Combine(path, fileName);
                    totalDeletedLines += RemoveString(filePath, output, stringToRemove);
                }

                return totalDeletedLines;
            }
        }

        public List<string> CreateListDocuments()
        {
            var filesNameList = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                var fileName = $"test_{i}.txt";
                filesNameList.Add(fileName);

                GenerateDoc(fileName);
            }

            return filesNameList;
        }

        public int RemoveString(string filePath, FileStream output, string stringToRemove)
        {
            var countDeletedLinesInFile = 0;

            using (var input = File.OpenRead(filePath))
            using (var reader = new StreamReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains(stringToRemove))
                    {
                        byte[] lineBytes = Encoding.UTF8.GetBytes(line + Environment.NewLine);
                        output.Write(lineBytes, 0, lineBytes.Length);
                    }
                    else
                    {
                        countDeletedLinesInFile++;
                    }
                }
            }

            return countDeletedLinesInFile;
        }

        public void StoredDocument(string filePath)
        {
            var lines = File.ReadAllLines(Path.Combine(filePath, "output.txt"));

            var docEntity = new TblDocument()
            {
                Name = "output.txt"
            };

            var importedCount = 0;
            var remainingCount = lines.Length;

            _b1Context.TblDocuments.Add(docEntity);
            _b1Context.SaveChanges();

            foreach (var line in lines)
            {
                var parsedLine = ParseLine(line);

                if (parsedLine != null)
                {
                    var tblContent = new TblContent()
                    {
                        Date = parsedLine.Date,
                        StringEU = parsedLine.StringEU,
                        StringRU = parsedLine.StringRU,
                        PositiveNumber = parsedLine.PositiveNumber,
                        FolatNumber = parsedLine.FolatNumber,
                        TblDocumentId = docEntity.Id,
                    };
                    _b1Context.TblContents.Add(tblContent);
                    _b1Context.SaveChanges();
                }
                remainingCount--;
                importedCount++;

                _processHub.Clients.All.SendAsync("UploadProcess", importedCount, remainingCount);
            }

        }

        private Content ParseLine(string line)
        {
            var parts = line.Split("||");

            if (parts.Length == 6)
            {
                return new Content
                {
                    Date = parts[0],
                    StringEU = parts[1],
                    StringRU = parts[2],
                    PositiveNumber = parts[3],
                    FolatNumber = parts[4]
                };
            }
            else
            {
                return null;
            }
        }

        public void GenerateDoc(string fileName)
		{
			FileInfo textFile = new FileInfo($@"C:\Users\dimai\Desktop\Files\{fileName}");
			using (StreamWriter sw = textFile.CreateText())
			{
				for (int i = 0; i < 100000; i++)
				{
					sw.WriteLine(GenerateStringForDoc());
				}
			}
		}

		public string GenerateRandomPositiveNumber()
		{
			var rnd = new Random();
			var number = rnd.Next(100000000);

			if (number % 2 == 0)
				return number.ToString();

			return GenerateRandomPositiveNumber();
		}

		public string GenerateRandomDate()
		{
			DateTime lastDate = DateTime.Today;
			DateTime firstDate = lastDate.AddYears(-5);

			int range = (lastDate - firstDate).Days;

			var rnd = new Random();
			DateTime randomDate = firstDate.AddDays(rnd.Next(range));

			return randomDate.ToString("dd.MM.yyyy");
		}

		public string GenerateRandomStringEU()
		{
			var rnd = new Random();
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			return new string(Enumerable.Repeat(chars, 10)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		public string GenerateRandomStringRU()
		{
			var rnd = new Random();
			var chars = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";
			return new string(Enumerable.Repeat(chars, 10)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		public string GenerateRandomDouble()
		{
			var rnd = new Random();

			double minValue = 1.0;
			double maxValue = 20.0;
			int decimalPlaces = 8;

			var range = rnd.NextDouble() * (maxValue - minValue) + minValue;
			var result = Math.Round(range, decimalPlaces);

			return result.ToString("0.00000000");
		}

		public string GenerateStringForDoc()
		{
			var doc = new Content()
			{
				Date = GenerateRandomDate(),
				StringEU = GenerateRandomStringEU(),
				StringRU = GenerateRandomStringRU(),
				PositiveNumber = GenerateRandomPositiveNumber(),
				FolatNumber = GenerateRandomDouble()
			};
	
			var result = $"{doc.Date}||{doc.StringEU}||{doc.StringRU}||{doc.PositiveNumber}||{doc.FolatNumber}||";

			return result;
		}


	}
}
