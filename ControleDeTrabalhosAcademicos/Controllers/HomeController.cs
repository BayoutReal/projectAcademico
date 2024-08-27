using Microsoft.AspNetCore.Mvc;

namespace ControleDeTrabalhosAcademicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}