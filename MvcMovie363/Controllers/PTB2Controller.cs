using Microsoft.AspNetCore.Mvc;
using System;

public class PTB2Controller : Controller
{
    // GET: /PTB2/Solve (Hiển thị form)
    public IActionResult Solve()
    {
        return View("~/Views/Person/Solve.cshtml");
    }

    // POST: Giải phương trình
    [HttpPost]
    public IActionResult Solve(double A, double B, double C) 
    {
        string result = "";
        if (A == 0)
        {
            if (B == 0)
            {
                result = C == 0 ? "Phương trình vô số nghiệm." : "Phương trình vô nghiệm.";
            }
            else
            {
                double x = -C/B;
                result = $"Đây là phương trình bậc 1. Nghiệm: x = {x}";
            }
        }
        else 
        {
            double delta = B*B - 4*A*C;

            if (delta < 0)
            {
                result = "Phương trình vô nghiệm";
            }
            else if (delta == 0)
            {
                double x = -B/(2*A);
                result = $"Phương trình có nghiệm kép: $x_1 = x_2 = {x}$";
            }
            else
            {
                double sqrtDelta = Math.Sqrt(delta);
                double x1 = (-B + sqrtDelta) / (2 * A);
                double x2 = (-B - sqrtDelta) / (2 * A);
                result = $"Phương trình có hai nghiệm phân biệt: x1 = {x1} và x2 = {x2}";
            }
        }
        ViewBag.KetQua = $"==><b>{result}</b>"; 
        ViewBag.A = A;
        ViewBag.B = B;
        ViewBag.C = C;
        
        return View("~/Views/Person/Solve.cshtml");
    }
}