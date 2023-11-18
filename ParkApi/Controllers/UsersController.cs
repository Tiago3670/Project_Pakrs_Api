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

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers() 
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
      
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<Users>> GetUserbyId(int id)
        {
            try
            {
                
                var user = await  _context.Users.FindAsync(id);

                if(user!=null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid user data");

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult>CreateUser([FromBody] Users _user) 
        {
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
                
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("EditUser/{id}")]
        public IActionResult EditUser(int id, [FromBody] Users updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("Invalid user data");
            }

            var existingUser = _context.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            try
            {
                if(updatedUser.Username!=null) { existingUser.Username = updatedUser.Username; }
                
                if(updatedUser.Email!=null)   { existingUser.Email = updatedUser.Email;}

                if(updatedUser.Password!=null) { existingUser.Password = updatedUser.Password;}
            

                _context.SaveChanges();

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _context.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            try
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        
        

       
    }
}
