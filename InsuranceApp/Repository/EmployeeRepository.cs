using InsuranceApp.Data;
using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly InsuranceContext _context;
        public EmployeeRepository(InsuranceContext context) { _context = context; }
        public Employee GetByEmailAndPassword(string email, string password) => _context.Employees.SingleOrDefault(e => e.Email == email && e.Password == password);
    }
}
