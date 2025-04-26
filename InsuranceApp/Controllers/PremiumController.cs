using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class PremiumController : Controller
    {
        [HttpGet("Calculate")]
        public IActionResult Calculate()
        {
            return View(new PremiumInputModel());
        }

        [HttpPost("Calculate")]
        public IActionResult Calculate(PremiumInputModel model)
        {
            model.EstimatedPremium = CalculatePremium(model);
            return View(model);
        }

        private decimal CalculatePremium(PremiumInputModel input)
        {
            decimal baseRate = 0.02M;

            if (input.PolicyType == "Life") baseRate = 0.015M;
            if (input.PolicyType == "Health") baseRate = 0.025M;

            decimal ageFactor = input.Age > 45 ? 1.5M : 1.2M;
            decimal total = input.CoverageAmount * baseRate * ageFactor * input.TenureYears;

            return Math.Round(total, 2);
        }
    }
}
