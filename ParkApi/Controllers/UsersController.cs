using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkApi.Data;
using ParkApi.model;

namespace ParkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDbContext context, ILogger<UsersController> logger) { 
        
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers() 
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"Error retrieving users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public  IActionResult CreateUser([FromBody] Users _user) 
        {
            _logger.LogInformation($"Attempting to create user: {_user.Username}");

            if (_user == null)
            {
                return BadRequest("Invalid user data");
            }

            try
            {
                _context.Users.Add(_user);
                _context.SaveChanges();

                return Ok(_user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}
