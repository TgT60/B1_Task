using B1_Task.Entity;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Globalization;
using B1_Task.Entity.BankEntities;
using B1_Task.Entity.BankEntityes;
using B1_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace B1_Task.Function.Excel
{
    public class ExcelFunction : IExcelFunction
    {
        private readonly B1Context _b1Context;

        public ExcelFunction(B1Context b1Context)
        {
            _b1Context = b1Context;
        }

        public async Task<List<TblBank>> GetBanks()
        {
            var banks = await _b1Context.TblBanks.ToListAsync();

            return banks;
        }
        public async Task<List<TblSheet>> GetSheets()
        {
            var sheets = await _b1Context.TblSheets.ToListAsync();

            return sheets;
        }

        public async Task<List<TblSheetClass>> GetSheetClasses()
        {
            var sheetClasses = await _b1Context.TblSheetClasses.ToListAsync();

            return sheetClasses;
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

            rows.RemoveAt(rows.Count - 1);
            return rows;
        }

        public async Task<List<string>> UploadToExcelEntities(Dictionary<string, List<string>> parsedData)
        {
            var rows = GetAllValues(parsedData);
            var bankName = GetBankName(rows[0]);

            var bankEntity = new TblBank()
            {
                Name = bankName,
            };
            await _b1Context.TblBanks.AddAsync(bankEntity);
            await _b1Context.SaveChangesAsync();

            var sheetName = rows[1];
            var sheetStarDate = GetStarSheetDate(rows[2]);
            var sheetEndDate = GetEndSheetDate(rows[2]);
            var sheetTotalSum = GetSheetTotalSum(rows);
            var sheetTotalSumValue = ParseSheetTotalBalanceRow(sheetTotalSum);

            var sheetEntity = new TblSheet()
            {
                Name = sheetName,
                StartDate = sheetStarDate,
                EndDate = sheetEndDate,
                TotalSumOpenActiveBalance = sheetTotalSumValue.TotalOpenActiveBalance,
                TotalSumOpenPassiveBalance = sheetTotalSumValue.TotalOpenPassiveBalance,
                TotalSumTurnoversCredit = sheetTotalSumValue.TotalTurnoversCredit,
                TotalSumTurnoversDebit = sheetTotalSumValue.TotalTurnoversDebit,
                TotalSumCloseActiveBalance = sheetTotalSumValue.TotalCloseActiveBalance,
                TotalSumClosePassiveBalance = sheetTotalSumValue.TotalClosePassiveBalance,
                TblBankId = bankEntity.Id,
            };

            await _b1Context.TblSheets.AddAsync(sheetEntity);
            await _b1Context.SaveChangesAsync();

            var sheetClassNameIndexList = GetAllSheetClassNameIndex(rows);
            var sheetClassSumIndexList = GetAllSheetClassSum(rows);

            var rowsForParse = GetAllValues(parsedData);

            for (int i = 0; i < sheetClassNameIndexList.Count; i++)
            {
                var classNameIndex = sheetClassNameIndexList[i];
                var classSumIndex = sheetClassSumIndexList[i];

                var sheetClassName = GetSheetClassName(rowsForParse, classNameIndex);
                var sheetClassSum = GetSheetClassSum(rowsForParse, classSumIndex);
                var parsedSheetClassSumRow = ParseSheetTotalBalanceRow(sheetClassSum);

                var sheetClassEntity = new TblSheetClass()
                {
                    Name = sheetClassName,
                    SumCloseActiveBalance = parsedSheetClassSumRow.TotalCloseActiveBalance,
                    SumClosePassiveBalance = parsedSheetClassSumRow.TotalClosePassiveBalance,
                    SumOpenActiveBalance = parsedSheetClassSumRow.TotalOpenActiveBalance,
                    SumOpenPassiveBalance = parsedSheetClassSumRow.TotalOpenPassiveBalance,
                    SumTurnoversCredit = parsedSheetClassSumRow.TotalTurnoversCredit,
                    SumTurnoversDebit = parsedSheetClassSumRow.TotalTurnoversDebit,
                    TblSheetId = sheetEntity.Id
                };

                await _b1Context.TblSheetClasses.AddAsync(sheetClassEntity);
                await _b1Context.SaveChangesAsync();

                var singleSheetClassData = GetSingleSheetClassData(rows, classNameIndex);
                var parsedSheetClassDataList = ParseSheetClassRows(singleSheetClassData);

                foreach (var parsedSheetClassData in parsedSheetClassDataList)
                {
                    var accountEntity = new TblAccount()
                    { 
                        Account = parsedSheetClassData.Account,
                        TblSheetClassId = sheetClassEntity.Id,
                    };

                    await _b1Context.TblAccounts.AddAsync(accountEntity);
                    await _b1Context.SaveChangesAsync();

                    var openingBalanceEntity = new TblOpeningBalance()
                    {
                        ActiveBalance = parsedSheetClassData.OpenActiveBalance, 
                        PassiveBalance = parsedSheetClassData.OpenPassiveBalance,
                        TblSheetClassId = sheetClassEntity.Id
                    };

                    await _b1Context.TblOpeningBalances.AddAsync(openingBalanceEntity);
                    await _b1Context.SaveChangesAsync();

                    var turnoverEntity = new TblTurnover()
                    {
                        Debit = parsedSheetClassData.TurnoversDebit,
                        Credit = parsedSheetClassData.TurnoversDebit,
                        TblSheetClassId = sheetClassEntity.Id
                    };

                    await _b1Context.TblTurnovers.AddAsync(turnoverEntity);
                    await _b1Context.SaveChangesAsync();

                    var closedBalanceEntity = new TblClosedBalance()
                    {
                        ActiveBalance = parsedSheetClassData.CloseActiveBalance,
                        PassiveBalance = parsedSheetClassData.ClosePassiveBalance,
                        TblSheetClassId = sheetClassEntity.Id
                    };

                    await _b1Context.TblClosedBalances.AddAsync(closedBalanceEntity);
                    await _b1Context.SaveChangesAsync();
                    }
                }
            return rows;
        }



        public string GetSheetClassName(List<string> rows,int sheetClassNameIndex)
        {
            return rows[sheetClassNameIndex];
        }
        public string GetSheetClassSum(List<string> rows, int sheetClassSumIndex)
        {
            return rows[sheetClassSumIndex];
        }

        public List<SheetClassRow> ParseSheetClassRows(List<string> sheetClassRows)
        {
            var result = new List<SheetClassRow>();

            foreach (string sheetClassRow in sheetClassRows)
            {
                var parts = sheetClassRow.Split(' ');

                var totalBalanceValues = new List<decimal>();

                for (int i = 0; i < parts.Length; i++)
                {
                    string valueString = parts[i];
                    valueString = valueString.Replace(',', '.');

                    if (decimal.TryParse(valueString, NumberStyles.AllowLeadingSign | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal value))
                    {
                        totalBalanceValues.Add(value);
                    }
                }

                var sheetRow = new SheetClassRow()
                {
                    Account = totalBalanceValues[0].ToString(),
                    OpenActiveBalance = totalBalanceValues[1],
                    OpenPassiveBalance = totalBalanceValues[2],
                    TurnoversDebit = totalBalanceValues[3],
                    TurnoversCredit = totalBalanceValues[4],
                    CloseActiveBalance = totalBalanceValues[5],
                    ClosePassiveBalance = totalBalanceValues[6],
                };

                result.Add(sheetRow);
            }

            return result;
        }

        public TotalSheetRow ParseSheetTotalBalanceRow(string balanceRow)
        {
            var parts = balanceRow.Split(' ');

            var totalBalanceValues = new List<decimal>();

            for (int i = 1; i < parts.Length; i++)
            {
                string valueString = parts[i];
                valueString = valueString.Replace(',', '.');

                if (decimal.TryParse(valueString, NumberStyles.AllowLeadingSign | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal value))
                {
                    totalBalanceValues.Add(value);
                }
            }

            var sheetRow = new TotalSheetRow()
            {
                TotalOpenActiveBalance = totalBalanceValues[0],
                TotalOpenPassiveBalance = totalBalanceValues[1],
                TotalTurnoversDebit = totalBalanceValues[2],
                TotalTurnoversCredit = totalBalanceValues[3],
                TotalCloseActiveBalance = totalBalanceValues[4],
                TotalClosePassiveBalance = totalBalanceValues[5],
            };

            return sheetRow;
        }

        public string GetSheetTotalSum(List<string> rows)
        {
            return rows.Last();
        }

        public List<string> RemoveHeaderFromRows(List<string> rows)
        {
            rows.RemoveRange(0,8);
            return rows;
        }

        public List<string> GetSingleSheetClassData(List<string> rows, int startIndex)
        {
            List<string> sheetSingleClassData = new List<string>();
            int classCount = 1;

            foreach (var (index, row) in rows.Skip(startIndex+1).Select((value, index) => (index + startIndex, value)))
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

            if (sheetSingleClassData.Count > 8)
            {
                sheetSingleClassData.RemoveAt(sheetSingleClassData.Count - 1);

                if (sheetSingleClassData.Count > 0)
                {
                    sheetSingleClassData.RemoveAt(sheetSingleClassData.Count - 1);
                }
            }

            return sheetSingleClassData;
        }

        public List<int> GetAllSheetClassNameIndex(List<string> rows)
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

        public List<int> GetAllSheetClassSum(List<string> rows)
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
