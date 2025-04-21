using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetAllPolicies();
        Policy GetPolicyById(int id);
        void AddPolicy(Policy policy);
        void UpdatePolicy(Policy policy);
        void DeletePolicy(int id);
    }
}
