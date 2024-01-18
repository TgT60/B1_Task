using B1_Task.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using B1_Task.Function.Document;

namespace B1_Task.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		IDocumentFunction _documentFunction;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Test()
		{
			var path = @"C:\Users\dimai\Desktop\Files\";
			_documentFunction.CreateCommonDoc(path,"ff");
			return RedirectToAction("Index");
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
