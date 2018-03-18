using Microsoft.AspNetCore.Mvc;

namespace KnockoutSurvey.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}