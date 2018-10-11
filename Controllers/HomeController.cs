using Microsoft.AspNetCore.Mvc;
namespace BLOOD_HELP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
