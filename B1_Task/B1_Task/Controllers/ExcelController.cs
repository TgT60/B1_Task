using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult ExcelFileReader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExcelFileReader(IFormFile file)
        {
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
            }

            return View();
        }
    }
}
