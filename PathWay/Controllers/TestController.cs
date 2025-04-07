using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Results()
        {
            return View();
        }
        public IActionResult CareerTests()
        {
            return View();
        }
    }
}
