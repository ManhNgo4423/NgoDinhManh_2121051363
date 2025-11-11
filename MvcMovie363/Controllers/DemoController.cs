using Microsoft.AspNetCore.Mvc;
using System.Text;
namespace MvcMovie363.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            ViewData["Message"] = "Your welcome message";

            return View();
        }
        //ViewResult
        public IActionResult ShowViewResult()
        {
            ViewBag.Message = "Đây là ví dụ về ViewResult";
            ViewBag.CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return View();
        }
        //RedirectResult
        public IActionResult ShowRedirectResult()
        {
            return Redirect("https://www.google.com");
        }
        //RedirectToActionResult
        public IActionResult ShowRedirectToActionResult()
        {
            return RedirectToAction("ShowViewResult");
        }

        // Action với tham số để demo RedirectToAction với parameters
        public IActionResult RedirectWithParams()
        {
            return RedirectToAction("TargetAction", new { id = 123, name = "Test" });
        }

        public IActionResult TargetAction(int id, string name)
        {
            ViewBag.Message = $"Nhận được tham số: ID={id}, Name={name}";
            return View("ShowViewResult");
        }
        //JsonResult
        public IActionResult ShowJsonResult()
        {
            var data = new
            {
                Success = true,
                Message = "Đây là ví dụ về JsonResult",
                Data = new
                {
                    Id = 1,
                    Name = "Nguyễn Văn A",
                    Email = "nguyenvana@example.com",
                    CreatedDate = DateTime.Now
                },
                Items = new[] { "Item 1", "Item 2", "Item 3" }
            };

            return Json(data);
        }
        //FileResult
        public IActionResult ShowFileResult()
        {
            string content = "Đây là nội dung file demo\n";
            content += "Dòng 2: FileResult example\n";
            content += $"Thời gian tạo: {DateTime.Now}";

            byte[] fileBytes = Encoding.UTF8.GetBytes(content);

            return File(fileBytes, "text/plain", "demo-file.txt");
        }

        // FileResult
        public IActionResult DownloadPdf()
        {
            byte[] pdfContent = Encoding.UTF8.GetBytes("Đây là nội dung giả lập file PDF");
            return File(pdfContent, "application/pdf", "document.pdf");
        }


        //StatusCodeResult
        public IActionResult ShowStatusCodeResult()
        {
            return StatusCode(404);
        }
    }
}
