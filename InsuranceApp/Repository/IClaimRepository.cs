using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public interface IClaimRepository
    {
        IEnumerable<InsuranceClaim> GetByCustomerId(int customerId);
    }
}
