using Microsoft.AspNetCore.Mvc;
using System;
using MvcMovie363.Models;

namespace MvcMovie363.Controllers
{
    public class Buoi4Controller : Controller
    {
        // 1. Dùng ViewBag, ViewData, TempData
        public IActionResult DemoDuLieu()
        {
            // 1.1. ViewBag và ViewData: Dữ liệu chỉ tồn tại trong Request hiện tại
            ViewBag.ThongBaoViewBag = "Chào mừng bạn đến với Buổi 4 - Dùng ViewBag!";
            ViewData["ThongBaoViewData"] = "Đây là thông báo từ ViewData.";

            // 1.2. TempData: Dữ liệu tồn tại cho Request hiện tại và Request tiếp theo (sau khi Redirect)
            // Ví dụ này sẽ được hiển thị khi Redirect sang action 'HienThiTempData'
            TempData["ThongBaoTempData"] = "Đây là thông báo từ TempData, sẽ được giữ lại sau khi Redirect.";
            
            // Chuyển hướng để minh họa TempData
            return RedirectToAction("HienThiTempData");

            // Nếu muốn hiển thị ViewBag/ViewData/TempData trong cùng 1 View, chỉ cần return View();
        }

        public IActionResult HienThiTempData()
        {
            // TempData["ThongBaoTempData"] sẽ được đọc ở đây (và bị xóa sau khi đọc, trừ khi dùng Peek)
            return View(); // View: HienThiTempData.cshtml
        }



        // 2. Gửi nhận dữ liệu giữa Controller và View (minh họa View -> Controller qua Query String)
        // Action nhận yêu cầu và trả về View
        public IActionResult NhapTen()
        {
            return View(); // View: NhapTen.cshtml
        }

        // Action nhận dữ liệu từ View (qua Query String)
        [HttpGet] // Chỉ định phương thức HTTP GET
        public IActionResult ChucMung(string tenNguoiDung)
        {
            if (string.IsNullOrEmpty(tenNguoiDung))
            {
                ViewBag.Loi = "Vui lòng nhập tên!";
                return View("NhapTen"); // Trở lại View nhập liệu
            }
            ViewBag.Ten = tenNguoiDung;
            return View(); // View: ChucMung.cshtml
        }



        // 3. Action trả về View nhập liệu (FORM GET)
        [HttpGet]
        public IActionResult NhapHocSinh()
        {
            return View(); // View: NhapHocSinh.cshtml
        }

        // 3. Action nhận dữ liệu Model từ View và xử lý (FORM POST)
        [HttpPost]
        public IActionResult XuLyHocSinh(HocSinh hocSinh) // Tham số nhận trực tiếp Model
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của Model (nếu có validation)
            {
                // Xử lý dữ liệu: Lưu vào DB, tính toán, ... (Ở đây chỉ mô phỏng)
                // Ví dụ: Tăng tuổi lên 1
                hocSinh.Tuoi += 1;

                // Gửi dữ liệu Model đã xử lý sang View để hiển thị
                return View("HienThiHocSinh", hocSinh); // View: HienThiHocSinh.cshtml
            }
            
            // Nếu Model không hợp lệ, quay lại View nhập liệu
            return View("NhapHocSinh", hocSinh);
        }
    }
}