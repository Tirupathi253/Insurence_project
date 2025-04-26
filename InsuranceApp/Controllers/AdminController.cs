using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsuranceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly InsuranceContext _context;

        public AdminController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            var totalCustomers = _context.Customers.Count();
            var totalPolicies = _context.Policies.Count();
            var totalClaims = _context.Claims.Count();
            var totalPayments = _context.Payments.Sum(p => p.Amount);

            ViewBag.Customers = totalCustomers;
            ViewBag.Policies = totalPolicies;
            ViewBag.Claims = totalClaims;
            ViewBag.Payments = totalPayments;

            return View();
        }
    }
}
