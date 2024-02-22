using Microsoft.AspNetCore.Mvc;

namespace BalloonWorld.Controllers
{
    public class BalloonWorld : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Welcome()
        {
            return "This is the welcome action method..";
        }
    }
}
