using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathWay.Context;
using PathWay.Models;

namespace PathWay.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        bool _authenticated = false;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string name, string email, string password, string password2)
        {
            if (await _context.Users.AnyAsync(i => i.Name == name))
            {
                ViewBag.Message = "The username is already registered";
                return View("Register");
            }

            if (await _context.Users.AnyAsync(i => i.Email == email))
            {
                ViewBag.Message = "The email already exists";
                return View("Register");
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z ]{2,}$"))
            {
                ViewBag.Message = "The name must contain only letters and spaces, with at least 2 characters.";
                return View("Register");
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ViewBag.Message = "Please enter a valid email";
                return View("Register");
            }

            if (password.Length < 6)
            {
                ViewBag.Message = "The password must be at least 6 characters long";
                return View("Register");
            }

            if (password != password2)
            {
                ViewBag.Message = "Passwords do not match";
                return View("Register");
            }

            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = new User
            {
                Name = name,
                Email = email,
                Password = passwordHashed,
                Created_At = DateTime.Now
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Please fill in all fields";
                return View();
            }
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);

            if (user == null)
            {
                ViewBag.Message = "The user does not exist";
                return View("Register");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                ViewBag.Message = "Incorrect password";
                return View("Login");
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("_authenticated", "true");
            _authenticated = true;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
