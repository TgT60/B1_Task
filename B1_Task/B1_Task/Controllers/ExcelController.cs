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
            _excelFunction =excelFunction;
        }
        public IActionResult ExcelFileReader()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ExcelFileReader(IFormFile file)
        {
            var flatData = await _excelFunction.ProcessExcelFile(file);
            var testColumnMethod = await _excelFunction.ProcessExcelFileForDictionary(file);
            var testRowMethod = _excelFunction.GetAllValues(testColumnMethod);


            if (flatData != null)
            {
                var viewModel = new ExcelModel { FlatData = testColumnMethod };

                return View(viewModel);
            }

            return BadRequest("Failed to process Excel file");
        }
    }
}
