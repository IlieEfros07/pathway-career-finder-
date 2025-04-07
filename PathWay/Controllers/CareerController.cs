using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult EducationPaths()
        {
            return View();
        }
    }
}
