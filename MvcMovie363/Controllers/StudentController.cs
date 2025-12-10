using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie363.Controllers{
public class StudentController : Controller
{
public IActionResult Index()
{
return View();
}
}
}