using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string? FullName, int NamSinh = 0) 
    { 
        string strOutput = "";
        if (string.IsNullOrEmpty(FullName))
        {
            ViewBag.Message = "Vui lòng nhập Tên";
            return View(); 
        }

        strOutput = $"Xin chào {FullName}";

        ViewBag.FullName = FullName;
        ViewBag.NamSinh = NamSinh;
        
        int currentYear = DateTime.Now.Year;
        int age = 0;

        if (NamSinh > 1900 && NamSinh < currentYear)
        {
            age = currentYear - NamSinh;
            strOutput += $". Năm nay bạn {age} tuổi.";
        } 
        else if (NamSinh != 0)
        {
             strOutput += $". Năm sinh {NamSinh} không hợp lệ.";
        }

        ViewBag.Message = strOutput;
        
        return View();
    }
}