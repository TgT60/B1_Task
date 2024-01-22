using B1_Task.Entity;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<Dictionary<string, List<string>>> ProcessExcelFileForHeader(IFormFile file)
        {
            var excelData = await UploadExcelFile(file);

            if (excelData != null && excelData.Count > 6)
            {
                var parsedData = new Dictionary<string, List<string>>();
                var headers = excelData[6];

                for (int colIndex = 0; colIndex < headers.Count; colIndex++)
                {
                    var header = headers[colIndex];
                    var columnData = new List<string>();

                    for (int rowIndex = 7; rowIndex < excelData.Count; rowIndex++)
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



    }
}
