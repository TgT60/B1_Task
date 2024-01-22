using B1_Task.Entity;
using B1_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B1_Task.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly B1Context _b1Context;

        public ProcedureController(B1Context b1Context)
        {
            _b1Context = b1Context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult StartProcedure()
        {
            _b1Context.Database.ExecuteSqlRaw("EXEC CalculateSumAndMedianForTblContent");
            var result = _b1Context.TblProcedureResults.FirstOrDefault();

            ViewBag.TotalSumPositive = result.TotalSumPositive;
            ViewBag.MedianValue = result.MedianValue;

            return View("Result");
        }


    }
}
