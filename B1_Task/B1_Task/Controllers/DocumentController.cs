using B1_Task.Function.Document;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Controllers
{
	public class DocumentController : Controller
	{
        readonly IDocumentFunction _documentFunction;
        private const string _path = @"C:\Users\dimai\Desktop\Files\";

		public DocumentController(IDocumentFunction documentFunction)
		{
			_documentFunction = documentFunction ;
		}

		public ActionResult Index()
		{
			return View();
		}

        [HttpPost]
		public ActionResult ProcessDocuments([FromBody] string path, [FromBody] string stringToDelete)
		{
			var totalDeletedLines = _documentFunction.CreateCommonDoc(_path, "ff");
            ViewBag.TotalDeletedLines = totalDeletedLines;

            return View("Result");
        }

        [HttpPost]
        public ActionResult StoredDocument()
        {
            _documentFunction.StoredDocument(_path);

            return Ok();
        }
    }
}
