using InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InsuranceClaim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}
