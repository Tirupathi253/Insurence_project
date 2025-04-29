using InsuranceApp.Models;
using InsuranceApp.Repository;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceApp.Controllers
{

    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly InsuranceContext _context;
        private readonly EmailService _email;

        public EmployeeController(InsuranceContext context, EmailService email)
        {
            _context = context;
            _email = email;
        }

        // GET: /Employee/Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Employee/Login
        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    var employee = _context.Employees.FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);

        //    if (employee != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, employee.Email),
        //            new Claim(ClaimTypes.Role, "Employee")
        //        };

        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new ClaimsPrincipal(identity);

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //        return RedirectToAction("Dashboard");
        //    }

        //    ViewBag.Error = "Invalid credentials.";
        //    return View();
        //}
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Dummy credentials for demo
            if (model.Email == "employee@example.com" && model.Password == "pass123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Email),
            new Claim(ClaimTypes.Role, "Employee")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid dummy credentials.";
            return View();
        }

        // POST: /Employee/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Employee");
        }

        // GET: /Employee/Dashboard
        [Authorize(Roles = "Employee")]
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: /Employee/Claims
        [Authorize(Roles = "Employee")]
        [HttpGet("Claims")]
        public IActionResult Claims()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }

        // POST: /Employee/Approve
        [Authorize(Roles = "Employee")]
        [HttpPost("Approve")]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();

                var customer = _context.Customers.FirstOrDefault(c => c.Id == claim.CustomerId);
                if (customer != null)
                {
                    _email.SendEmail(
                        customer.Email,
                        "Claim Approved - Insurance App",
                        $"Dear {customer.FullName},<br/><br/>Your claim #{claim.Id} has been <strong>approved</strong>.<br/><br/>Thank you."
                    );
                }
            }
            return RedirectToAction("Claims");
        }

        // POST: /Employee/Reject
        [Authorize(Roles = "Employee")]
        [HttpPost("Reject")]
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();

                var customer = _context.Customers.FirstOrDefault(c => c.Id == claim.CustomerId);
                if (customer != null)
                {
                    _email.SendEmail(
                        customer.Email,
                        "Claim Rejected - Insurance App",
                        $"Dear {customer.FullName},<br/><br/>Unfortunately, your claim #{claim.Id} has been <strong>rejected</strong>.<br/><br/>Thank you."
                    );
                }
            }
            return RedirectToAction("Claims");
        }
    }
}
