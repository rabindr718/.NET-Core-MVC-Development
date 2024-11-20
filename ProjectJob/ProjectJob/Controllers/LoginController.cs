using Microsoft.AspNetCore.Mvc;

namespace ProjectJob.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "admin@example.com" && password == "password123")
            {
                TempData["IsAuthenticated"] = true;

                return RedirectToAction("List", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid login attempt.";
                return View();
            }
        }
    }
}
