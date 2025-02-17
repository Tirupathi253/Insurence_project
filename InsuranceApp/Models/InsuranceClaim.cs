using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Models
{
    public class InsuranceClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public decimal ClaimAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
