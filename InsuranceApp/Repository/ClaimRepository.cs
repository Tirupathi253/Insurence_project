﻿using InsuranceApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly InsuranceContext _context;
        public ClaimRepository(InsuranceContext context) { _context = context; }

        public IEnumerable<InsuranceClaim> GetByCustomerId(int customerId) =>
            _context.Claims.Where(c => c.CustomerId == customerId).ToList();
    }

}
