using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public IActionResult Login() => View();

        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Email == "admin@example.com" && model.Password == "admin123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Email),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var identity = new ClaimsIdentity(claims, "Login");
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ViewBag.Error = "Invalid login.";
                return View();
            }
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }


    }
}
