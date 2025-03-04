using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApp.Models;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Welcome to the Insurance API");
    }
}
