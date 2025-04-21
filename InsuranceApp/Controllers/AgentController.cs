using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class AgentController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
