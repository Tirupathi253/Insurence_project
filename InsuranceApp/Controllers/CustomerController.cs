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
        private readonly InsuranceContext _context;

        public CustomerController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Email == "customer@example.com" && model.Password == "pass123")
            {
                TempData["Success"] = "Login successful!";
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials. Try again.";
            return View();
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            // Fetch counts from database
            var totalPolicies = _context.Policies.Count();
            var totalPayments = _context.Payments.Count();
            var totalClaims = _context.Claims.Count();

            // Send to view
            ViewBag.TotalPolicies = totalPolicies;
            ViewBag.TotalPayments = totalPayments;
            ViewBag.TotalClaims = totalClaims;

            return View();
        }

        [HttpGet("ClaimHistory")]
        public IActionResult ClaimHistory(int customerId)
        {
            var claims = _context.Claims.Where(c => c.CustomerId == customerId).ToList();
            return View(claims);
        }
        [HttpGet("Profile")]
        public IActionResult Profile(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null) return NotFound();

            return View(customer);
        }

        [HttpPost("Profile")]
        public IActionResult Profile(Customer updated)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == updated.Id);
            if (customer != null)
            {
                customer.FullName = updated.FullName;
                customer.Email = updated.Email;
                _context.SaveChanges();
                TempData["Message"] = "Profile updated successfully!";
            }
            return RedirectToAction("Dashboard");
        }

    }

}
