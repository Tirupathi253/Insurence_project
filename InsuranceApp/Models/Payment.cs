using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int PolicyId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMode { get; set; } // UPI, CreditCard, etc.

        public DateTime PaymentDate { get; set; }

        // 🔽 Add this to fix your error
        public int CustomerId { get; set; }

        // (Optional) Navigation property
        public Customer Customer { get; set; }
    }
}
