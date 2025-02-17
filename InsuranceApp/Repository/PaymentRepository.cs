using InsuranceApp.Data;
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
        public PaymentRepository(InsuranceContext context) { _context = context; }
        public IEnumerable<Payment> GetByCustomerId(int customerId) => _context.Payments.Where(p => p.CustomerId == customerId).ToList();
    }
}
