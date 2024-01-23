using B1_Task.Entity;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace B1_Task.Function.Excel
{
    public class ExcelFunction : IExcelFunction
    {
        private readonly B1Context _b1Context;

        public ExcelFunction(B1Context b1Context)
        {
            _b1Context = b1Context;
        }
        public async Task<List<List<object>>> UploadExcelFile(IFormFile file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (file != null && file.Length > 0)
            {
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                var filePath = Path.Combine(uploadDirectory, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return await ReadExcelData(filePath);
            }

            return null;
        }

        public async Task<List<List<object>>> ReadExcelData(string filePath)
        {
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var excelData = new List<List<object>>();

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            var rowData = new List<object>();
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                rowData.Add(reader.GetValue(column));
                            }
                            excelData.Add(rowData);
                        }
                    } while (reader.NextResult());

                    return excelData;
                }
            }
        }

        public async Task<List<string>> ProcessExcelFile(IFormFile file)
        {
            var excelData = await UploadExcelFile(file);

            if (excelData != null)
            {
                List<string> flatData = new List<string>();

                foreach (var row in excelData)
                {
                    string rowDataString = string.Join(", ", row.Select(cell => cell != null ? cell.ToString() : ""));
                    flatData.Add(rowDataString);
                }

                return flatData;
            }
            return null;
        }

        public async Task<Dictionary<string, List<string>>> ProcessExcelFileForDictionary(IFormFile file)
        {
            var excelData = await UploadExcelFile(file);

            if (excelData != null && excelData.Count > 6)
            {
                var parsedData = new Dictionary<string, List<string>>();

                for (int colIndex = 0; colIndex < 7; colIndex++)
                {
                    var columnData = new List<string>();

                    for (int rowIndex = 0; rowIndex < excelData.Count; rowIndex++)
                    {
                        var rowData = excelData[rowIndex];

                        if (colIndex < rowData.Count)
                        {
                            var cellValue = rowData[colIndex]?.ToString() ?? "";
                            columnData.Add(cellValue);
                        }
                    }

                    AddToParsedData(parsedData, $"Column_{colIndex + 1}", columnData);
                }

                return parsedData;
            }

            return null;
        }

        private void AddToParsedData(Dictionary<string, List<string>> parsedData, string key, List<string> columnData)
        {
            if (!parsedData.ContainsKey(key))
            {
                parsedData[key] = new List<string>();
            }

            parsedData[key].AddRange(columnData.Select(cell => cell?.ToString() ?? ""));
        }

        public List<string> GetAllValues(Dictionary<string, List<string>> parsedData)
        {
            List<string> rows = new List<string>();

            if (parsedData != null)
            {
                int maxRowCount = parsedData.Values.Max(column => column.Count);

                for (int rowIndex = 0; rowIndex < maxRowCount; rowIndex++)
                {
                    List<string> rowData = new List<string>();

                    foreach (var columnData in parsedData.Values)
                    {
                        if (rowIndex < columnData.Count)
                        {
                            rowData.Add(columnData[rowIndex]);
                        }
                        else
                        {
                            rowData.Add(" ");
                        }
                    }
            
                    string rowString = string.Join(" ", rowData).TrimEnd();
                    rows.Add(rowString);
                }
            }
            if (rows.Count > 0)
            {
                rows.RemoveAt(rows.Count - 1);
            }

            var sheetClassList = GetAllSheetClassesIndex(rows);
            var sheetClassSum = GetSheetClassSum(rows);
            var singleSheetClassData = GetSingleSheetClassData(rows);
            var bankName = GetBankName(rows[0]);
            var sheetName = rows[1];
            var sheetStarDate = GetStarSheetDate(rows[2]);
            var sheetEndDate = GetEndSheetDate(rows[2]);

            return rows;
        }

        public List<string> RemoveHeaderFromoRows(List<string> rows)
        {
            rows.RemoveRange(0,8);
            return rows;
        }

        public List<string> GetSingleSheetClassData(List<string> rows)
        {
            List<string> sheetSingleClassData = new List<string>();
            int classCount = 0;

            RemoveHeaderFromoRows(rows);

            foreach (var row in rows)
            {
                if (row.Contains("КЛАСС") && !row.Contains("ПО"))
                {
                    classCount ++;
                }

                if (classCount < 2)
                {
                    sheetSingleClassData.Add(row);
                }
                else
                {
                    break; 
                }
            }

            return sheetSingleClassData;
        }

        public List<int> GetAllSheetClassesIndex(List<string> rows)
        {
            var classPositions = new List<int>();

            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                if (row.Contains("КЛАСС") && !row.Contains("ПО"))
                {
                    classPositions.Add(i);
                }
            }

            return classPositions;
        }

        public List<int> GetSheetClassSum(List<string> rows)
        {
            var classPositions = new List<int>();

            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                if (row.Contains("ПО КЛАССУ"))
                {
                    classPositions.Add(i);
                }
            }

            return classPositions;
        }

        public string GetBankName(string input)
        {
            int startIndex = input.IndexOf("Название банка") + "Название банка".Length;
            return new string(input.Substring(startIndex).Trim());
        }

        public string GetStarSheetDate(string input)
        {
            string pattern = @"(\d{2}\.\d{2}\.\d{4}) по \d{2}\.\d{2}\.\d{4}";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "Start Date not found";
        }

        public string GetEndSheetDate(string input)
        {
            string pattern = @"\d{2}\.\d{2}\.\d{4} по (\d{2}\.\d{2}\.\d{4})";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "End Date not found";
        }

    }
}
