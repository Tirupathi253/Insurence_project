﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApp.Models;

namespace InsuranceApp.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
