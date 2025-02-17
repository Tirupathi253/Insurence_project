using InsuranceApp.Data;
using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceContext _context;
        public PolicyRepository(InsuranceContext context) { _context = context; }
        public IEnumerable<Policy> GetByCustomerId(int customerId) => _context.Policies.Where(p => p.CustomerId == customerId).ToList();
    }
}
