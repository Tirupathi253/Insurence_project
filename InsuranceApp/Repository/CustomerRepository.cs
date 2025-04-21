using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceContext _context;
        public CustomerRepository(InsuranceContext context) { _context = context; }
        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();
    }
}
