using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly InsuranceContext _context;

        public PaymentRepository(InsuranceContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetByCustomerId(int customerId) =>
            _context.Payments.Where(p => p.CustomerId == customerId).ToList();

        // Implement the ProcessPayment method
        public async Task<bool> ProcessPayment(int customerId, int policyId, decimal amount)
        {
            // Create a new Payment entity to save in the database (or your business logic here)
            var payment = new Payment
            {
                CustomerId = customerId,
                PolicyId = policyId,
                Amount = amount,
                PaymentDate = DateTime.Now
            };

            // Save the payment to the database (assuming _context is an EF Core DbContext)
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return true; // Indicating that payment processing was successful
        }
    }
}
