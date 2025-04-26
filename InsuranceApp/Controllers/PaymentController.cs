using InsuranceApp.Models;
using InsuranceApp.Repository;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly InsuranceContext _context;
        private readonly EmailService _email;

        public PaymentController(InsuranceContext context, EmailService email)
        {
            _context = context;
            _email = email;
        }

        [HttpPost("Pay")]
        public IActionResult Pay(Payment model)
        {
            model.PaymentDate = DateTime.Now;
            _context.Payments.Add(model);
            _context.SaveChanges();

            var customer = _context.Customers.FirstOrDefault(c => c.Id == model.CustomerId);
            if (customer != null)
            {
                string toEmail = "tirupathij123@gmail.com"; // or customer.Email
                string subject = "Payment Confirmation - Insurance App";
                string message = $"Dear {customer.FullName},<br/><br/>Your payment of ₹{model.Amount} for policy #{model.PolicyId} has been successfully received.<br/><br/>Thank you,<br/>Insurance App";
                _email.SendEmail(toEmail, subject, message);
            }

            TempData["Summary"] = $"You paid ₹{model.Amount} for Policy #{model.PolicyId}.";
            return RedirectToAction("Summary");
        }

        [HttpGet("Summary")]
        public IActionResult Summary()
        {
            return View();
        }

        [HttpGet("DownloadReceipt")]
        public IActionResult DownloadReceipt(int paymentId)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == paymentId);
            if (payment == null) return NotFound();

            var file = GeneratePdfReceipt(payment);
            return File(file, "application/pdf", "Receipt.pdf");
        }

        private byte[] GeneratePdfReceipt(Payment payment)
        {
            var doc = new PdfDocument();
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            gfx.DrawString("Payment Receipt", new XFont("Arial", 20), XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Customer ID: {payment.CustomerId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 100));
            gfx.DrawString($"Amount: ₹{payment.Amount}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 130));
            gfx.DrawString($"Date: {payment.PaymentDate}", new XFont("Arial", 12), XBrushes.Black, new XPoint(50, 160));

            using var stream = new MemoryStream();
            doc.Save(stream, false);
            return stream.ToArray();
        }
    }
}
