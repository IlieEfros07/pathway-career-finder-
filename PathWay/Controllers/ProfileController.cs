using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
