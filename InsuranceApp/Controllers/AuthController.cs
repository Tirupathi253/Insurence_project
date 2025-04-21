using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public IActionResult Login() => View();

        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Email == "user@insurance.com" && model.Password == "password")
            {
                return RedirectToAction("Dashboard", "Customer");
            }
            return View(model);
        }
    }
}
