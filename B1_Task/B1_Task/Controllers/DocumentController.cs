using B1_Task.Function.Document;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Controllers
{
	public class DocumentController : Controller
	{
        DocumentFunction _documentFunction;

		public DocumentController()
		{
			_documentFunction = new DocumentFunction();
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ProcessDocuments()
		{
			var path = @"C:\Users\dimai\Desktop\Files\";
			
			var totalDeletedLines = _documentFunction.CreateCommonDoc(path, "ff");

			ViewBag.TotalDeletedLines = totalDeletedLines;

            return View("Result");
        }
	}
}
