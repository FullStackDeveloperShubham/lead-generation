using LeadGenerationApp.Data;
using LeadGenerationApp.Dto;
using LeadGenerationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginRequest = LeadGenerationApp.Dto.LoginRequest;
//using LeadGenerationApp.Dto;
using System.Security;

namespace LeadGenerationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, AppDbContext dbContext)
        {
            _config = config;
            this.dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await dbContext.Users
                .Include(u => u.Role) // Ensure Role is loaded
                .FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var hasher = new PasswordHasher<Users>();
            var result = hasher.VerifyHashedPassword(user, user.UserPassword, request.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Invalid username or password" });

            // ✅ Role-based response
            string redirectUrl;
            if (user.Role.RollName == "Admin" || user.Role.RollName == "Manager")
            {
                redirectUrl = "/api/dashboard";
            }
            else
            {
                redirectUrl = "/api/leads";
            }

            return Ok(new
            {
                message = "Login successful",
                roleId = user.Role.RollID,
                role = user.Role.RollName,   
                redirectUrl = redirectUrl
            });
        }




    }
}
