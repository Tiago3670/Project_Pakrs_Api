using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkApi.Data;
using ParkApi.model;

namespace ParkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ILogger<ParkController> _logger;
        public ParkController(AppDbContext context, ILogger<ParkController> logger)
        {
            _context = context;
            _logger= logger;
        }


        [HttpGet("GetParks")]
        public async Task<ActionResult<IEnumerable<Parks>>> GetAllParks()
        {
            try
            {
                var users = await _context.Parks.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetParkById/{id}")]
        public async Task<ActionResult<Parks>> GetParkById(int id)
        {
            try 
            {
                var park=await _context.Parks.FindAsync(id);
                if(park!=null)
                {
                    return Ok(park);
                }
                else
                {
                    return BadRequest("Park not found");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        
        }

        [HttpPost("AddPark")]
        public async Task<ActionResult<Parks>> AddPark([FromBody] Parks _park)
        {
            if (_park == null)
            {
                return BadRequest("Invalid park data");
            }

            try
            {
                await _context.Parks.AddAsync(_park);
                _context.SaveChanges();

                return Ok(_park);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");

                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost("AddParkLocation")]
        public async Task<IActionResult> AddLocation([FromBody] LocationDetail _locationDetail)
        {
            if (_locationDetail == null)
            {
                return BadRequest("Invalid LocationDetail data");
            }

            try
            {


                await _context.LocationDetail.AddAsync(_locationDetail);
                Console.WriteLine("After AddAsync");

                await _context.SaveChangesAsync();
                Console.WriteLine("After SaveChangesAsync");

                return Ok(_locationDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

    }
}
