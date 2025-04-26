using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Linq;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class ClaimController : Controller
    {
        private readonly InsuranceContext _context;

        public ClaimController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpGet("Submit")]
        public IActionResult Submit()
        {
            ViewBag.Policies = _context.Policies.ToList();
            return View();
        }

        [HttpPost("Submit")]
        public IActionResult Submit(ClaimModel model)
        {
            var claim = new InsuranceClaim
            {
                CustomerId = model.CustomerId,
                PolicyId = model.PolicyId,
                Reason = model.Reason,
                Status = "Pending"
            };

            _context.Claims.Add(claim);
            _context.SaveChanges();

            TempData["Message"] = "Claim submitted successfully!";
            return RedirectToAction("Submit");
        }

        [HttpGet("History")]
        public IActionResult History(int customerId)
        {
            var claims = _context.Claims
                .Where(c => c.CustomerId == customerId)
                .ToList();
            return View(claims);
        }

        [HttpGet("DownloadReceipt")]
        public IActionResult DownloadReceipt(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == claimId);
            if (claim == null) return NotFound();

            var doc = new PdfDocument();
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            gfx.DrawString("Claim Receipt", new XFont("Arial", 20), XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Claim ID: {claim.Id}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 100));
            gfx.DrawString($"Customer ID: {claim.CustomerId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 130));
            gfx.DrawString($"Policy ID: {claim.PolicyId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 160));
            gfx.DrawString($"Status: {claim.Status}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 190));
            gfx.DrawString($"Reason: {claim.Reason}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 220));

            using var stream = new MemoryStream();
            doc.Save(stream, false);
            return File(stream.ToArray(), "application/pdf", "ClaimReceipt.pdf");
        }
    }
}
