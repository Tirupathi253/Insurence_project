using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class PolicyController : Controller
    {
        private readonly IPolicyRepository _repo;
        public PolicyController(IPolicyRepository repo)
        {
            _repo = repo;
        }

        public IActionResult List()
        {
            var policies = _repo.GetAllPolicies();
            return View(policies);
        }
    }
}
