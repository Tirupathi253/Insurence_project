using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{

    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // GET: Customer/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Customer/Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Dummy credentials for demo
            if (model.Email == "customer@example.com" && model.Password == "pass123")
            {
                TempData["Success"] = "Login successful!";
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials. Try again.";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
