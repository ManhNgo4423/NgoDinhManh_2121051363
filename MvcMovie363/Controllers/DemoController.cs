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
        // 1. ViewResult - Trả về một View
        public IActionResult ShowViewResult()
        {
            ViewBag.Message = "Đây là ví dụ về ViewResult";
            ViewBag.CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return View();
        }
        // 2. RedirectResult - Chuyển hướng đến một URL cụ thể
        public IActionResult ShowRedirectResult()
        {
            // Chuyển hướng đến Google
            return Redirect("https://www.google.com");
        }
        // 3. RedirectToActionResult - Chuyển hướng đến Action khác
        public IActionResult ShowRedirectToActionResult()
        {
            // Chuyển hướng đến action ShowViewResult
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
        // 4. JsonResult - Trả về dữ liệu dạng JSON
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
        // 5. FileResult - Trả về file để download
        public IActionResult ShowFileResult()
        {
            // Tạo nội dung file text
            string content = "Đây là nội dung file demo\n";
            content += "Dòng 2: FileResult example\n";
            content += $"Thời gian tạo: {DateTime.Now}";

            byte[] fileBytes = Encoding.UTF8.GetBytes(content);

            return File(fileBytes, "text/plain", "demo-file.txt");
        }

        // FileResult - Trả về file PDF (giả lập)
        public IActionResult DownloadPdf()
        {
            // Trong thực tế, bạn sẽ đọc file từ server
            byte[] pdfContent = Encoding.UTF8.GetBytes("Đây là nội dung giả lập file PDF");
            return File(pdfContent, "application/pdf", "document.pdf");
        }

        // FileResult - Trả về hình ảnh
        public IActionResult ShowImage()
        {
            // Tạo một pixel đỏ đơn giản (1x1 PNG)
            byte[] imageBytes = Convert.FromBase64String(
                "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8DwHwAFBQIAX8jx0gAAAABJRU5ErkJggg=="
            );
            return File(imageBytes, "image/png");
        }
        // 6. StatusCodeResult - Trả về mã trạng thái HTTP
        public IActionResult ShowStatusCodeResult()
        {
            // Trả về 404 Not Found
            return StatusCode(404);
        }

        public IActionResult ShowStatusCode200()
        {
            return StatusCode(200, "OK - Request thành công");
        }

        public IActionResult ShowStatusCode500()
        {
            return StatusCode(500, "Internal Server Error");
        }

        // Các helper methods cho status codes phổ biến
        public IActionResult ShowNotFound()
        {
            return NotFound("Không tìm thấy tài nguyên");
        }

        public IActionResult ShowBadRequest()
        {
            return BadRequest("Yêu cầu không hợp lệ");
        }

        public IActionResult ShowUnauthorized()
        {
            return Unauthorized();
        }
    }
}
