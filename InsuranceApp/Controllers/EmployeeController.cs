using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{

    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository) { _repository = repository; }

        
        [HttpPost("login")]
        public ActionResult<Employee> Login([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrEmpty(employee.Email) || string.IsNullOrEmpty(employee.Password))
            {
                return BadRequest("Invalid request data");
            }

            var user = _repository.GetByEmailAndPassword(employee.Email, employee.Password);
            if (user == null)
            {
                return Unauthorized(); // Correct method usage
            }

            return Ok(user);
        }

    }
}
