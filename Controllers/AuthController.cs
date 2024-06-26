using Microsoft.AspNetCore.Mvc;
using A2test.Models;
using System.Linq;

namespace A2test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EmiasContext _context;

        public AuthController(EmiasContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Polis.Length != 16 || !long.TryParse(request.Polis, out _))
            {
                return BadRequest("Invalid polis number");
            }

            var user = _context.Users.FirstOrDefault(u => u.Polis == request.Polis);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(new { Message = "Login successful" });
        }
    }

    public class LoginRequest
    {
        public string Polis { get; set; }
    }
}