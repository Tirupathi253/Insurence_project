using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class ClaimController : Controller
    {
        [HttpGet("Submit")]
        public IActionResult Submit() => View();

        [HttpPost("Submit")]
        public IActionResult Submit(ClaimModel model)
        {
            // Here we’d normally call repository to store this
            TempData["Message"] = "Claim submitted successfully.";
            return RedirectToAction("Submit");
        }
    }
}
