using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public decimal Premium { get; set; }
        public int TermYears { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
