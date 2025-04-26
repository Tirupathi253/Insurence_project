using InsuranceApp.Models;
using InsuranceApp.Repository;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Dashboard() => View();

        [HttpGet("Claims")]
        public IActionResult Claims()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }

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
                    _email.SendEmail("tirupathij123@gmail.com", "Claim Approved",
                    $"Dear {customer.FullName}, your insurance claim #{claim.Id} has been approved.");
                }
            }
            return RedirectToAction("Claims");
        }

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
                    _email.SendEmail("tirupathij123@gmail.com", "Claim Rejected",
                    $"Dear {customer.FullName}, unfortunately your insurance claim #{claim.Id} has been rejected.");
                }
            }
            return RedirectToAction("Claims");
        }
    }
}
