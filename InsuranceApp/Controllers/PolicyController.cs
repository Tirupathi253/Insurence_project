using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _repository;
        public PolicyController(IPolicyRepository repository) { _repository = repository; }

        [HttpGet("{customerId}")]
        public IActionResult GetByCustomerId(int customerId) => Ok(_repository.GetByCustomerId(customerId));
    }
}
