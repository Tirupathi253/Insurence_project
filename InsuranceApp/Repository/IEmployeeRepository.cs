using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetByEmailAndPassword(string email, string password);
    }
}
