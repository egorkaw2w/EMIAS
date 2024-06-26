using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A2test.Models;

namespace PRAK10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorAuthController : ControllerBase
    {
        private readonly ILogger<DoctorAuthController> _logger;
        private readonly EmiasContext _context;

        public DoctorAuthController(ILogger<DoctorAuthController> logger, EmiasContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVrachRequest request)
        {
            if (request == null || !request.Id.HasValue || string.IsNullOrEmpty(request.EnterPassword))
            {
                return BadRequest("Invalid input");
            }

            var vrach = await _context.DoctorTables
                .FirstOrDefaultAsync(v => v.Id == request.Id && v.EnterPassword == request.EnterPassword);

            if (vrach == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Message = "Login successful" });
        }
    }

    public class LoginVrachRequest
    {
        public int? Id { get; set; }
        public string EnterPassword { get; set; }
    }
}