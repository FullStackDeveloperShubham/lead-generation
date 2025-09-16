using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadGenerationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "Welcome to Dashboard (Admin/Manager)" });
        }
    }
}
