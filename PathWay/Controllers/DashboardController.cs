using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class DashboardController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
