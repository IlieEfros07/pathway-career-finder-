using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
