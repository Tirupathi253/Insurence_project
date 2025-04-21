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
        public PolicyRepository(InsuranceContext context)
        {
            _context = context;
        }
        public IEnumerable<Policy> GetAllPolicies() => _context.Policies.ToList();
        public Policy GetPolicyById(int id) => _context.Policies.Find(id);
        public void AddPolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            _context.SaveChanges();
        }
        public void UpdatePolicy(Policy policy)
        {
            _context.Policies.Update(policy);
            _context.SaveChanges();
        }
        public void DeletePolicy(int id)
        {
            var policy = _context.Policies.Find(id);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
                _context.SaveChanges();
            }
        }
    }
}
