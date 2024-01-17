using B1_Task.Function.Document;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Controllers
{
	public class DocumentController : Controller
	{
        IDocumentFunction _documentFunction;

		public DocumentController(IDocumentFunction documentFunction)
		{
			_documentFunction = documentFunction ;
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

            _documentFunction.StoredDocument(path);

            ViewBag.TotalDeletedLines = totalDeletedLines;

            return View("Result");
        }

        public ActionResult StoreDocument()
        {
            var path = @"C:\Users\dimai\Desktop\Files\";

          


            return View("Result");
        }
    }
}
