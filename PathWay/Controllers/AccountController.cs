using Microsoft.AspNetCore.Mvc;

namespace PathWay.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Settings()
        {
            return View();
        }
    }
}
