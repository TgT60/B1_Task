using B1_Task.Function.Excel;
using B1_Task.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Controllers
{
    public class ExcelController : Controller
    {
        private IExcelFunction _excelFunction;

        public ExcelController(IExcelFunction excelFunction)
        {
            _excelFunction = excelFunction;
        }
        public IActionResult ExcelFileReader()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ExcelFileReader(IFormFile file)
        {
            var testColumnMethod = await _excelFunction.ProcessExcelFileForDictionary(file);
            await _excelFunction.UploadToExcelEntities(testColumnMethod);

            return View("Result");
        }

        public async Task<IActionResult> ExcelData()
        {
            var banks = await _excelFunction.GetBanks();
            var sheets = await _excelFunction.GetSheets();
            var sheetClasses = await _excelFunction.GetSheetClasses();


            var viewModel = new ExcelViewModel()
            {
                Banks = banks,
                Sheets = sheets,
                SheetClasses = sheetClasses
            };

            return View(viewModel);
        }

        public IActionResult ExcelFileList()
        {
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

            string[] files = Directory.GetFiles(uploadPath);

            return View(files);
        }
    }
}
