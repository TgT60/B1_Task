using B1_Task.Function.Excel;
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
            ViewBag.ExcelData = await _excelFunction.ProcessExcelFile(file);
            return View();
        }
    }
}
