using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Models
{
    public class InsuranceClaim
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PolicyId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
