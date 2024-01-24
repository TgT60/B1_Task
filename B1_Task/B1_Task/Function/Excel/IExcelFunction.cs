using B1_Task.Entity.BankEntityes;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Function.Excel
{
    public interface IExcelFunction
    {
        Task<List<List<object>>> UploadExcelFile(IFormFile file);
        Task<List<List<object>>> ReadExcelData(string filePath);
        Task<List<string>> ProcessExcelFile(IFormFile file);
        Task<Dictionary<string, List<string>>> ProcessExcelFileForDictionary(IFormFile file);
        List<string> GetAllValues(Dictionary<string, List<string>> parsedData);
        Task<List<string>> UploadToExcelEntities(Dictionary<string, List<string>> parsedData);
        Task<List<TblBank>> GetBanks();
        Task<List<TblSheet>> GetSheets();
        Task<List<TblSheetClass>> GetSheetClasses();

    }
}
