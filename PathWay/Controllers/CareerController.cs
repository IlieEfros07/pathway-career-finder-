using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
