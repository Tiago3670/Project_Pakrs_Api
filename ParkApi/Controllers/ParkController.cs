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

        [HttpGet("GetLocations")]
        public async Task<ActionResult<IEnumerable<LocationDetail>>> GetAllLocations()
        {
            try
            {
                var locations = await _context.LocationDetail.ToListAsync();

                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetFeatures")]
        public async Task<ActionResult<IEnumerable<FeaturesList>>> GetAllFeatures()
        {
            try
            {
                var features = await _context.FeaturesList.ToListAsync();

                return Ok(features);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetParks")]
        public async Task<ActionResult<IEnumerable<Parks>>> GetAllParks()
        {
            try
            {
                var parks = await _context.Parks
                           .Include(p => p.Features)
                           .Include(p => p.Location)
                           .ToListAsync(); 
                
                return Ok(parks);
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
                var park = await _context.Parks
                                            .Include(p => p.Features)
                                            .Include(p => p.Location)
                                            .FirstOrDefaultAsync(p => p.ParkId == id); 
                
                if (park!=null)
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


        [HttpPut("EditPark/{id}")]
        public async Task<ActionResult<Parks>> EditPark(int id, [FromBody] Parks update_park)
        {
            if(update_park==null)
            {
                return BadRequest("Invalid Data");
            }

            var exist_park = await _context.Parks
                .Include(p => p.Features)
                .Include(p => p.Location)
                .FirstOrDefaultAsync(p => p.ParkId == id);
            if (exist_park == null)
            {
                return NotFound("Park not found");
            }

            try
            {
                if(update_park.Features!=null)
                {
                    if(update_park.Features.Food!=null)
                    {
                        exist_park.Features.Food = update_park.Features.Food;
                    }

                    if (update_park.Features.Shops != null)
                    {
                        exist_park.Features.Shops = update_park.Features.Shops;
                    }

                    if (update_park.Features.Entertainment != null)
                    {
                        exist_park.Features.Entertainment = update_park.Features.Entertainment;
                    }

                    if (update_park.Features.Gym != null)
                    {
                        exist_park.Features.Gym = update_park.Features.Gym;
                    }

                    if (update_park.Features.PetsAllowed != null)
                    {
                        exist_park.Features.PetsAllowed = update_park.Features.PetsAllowed;
                    }

                    if (update_park.Features.WiFi != null)
                    {
                        exist_park.Features.WiFi = update_park.Features.WiFi;
                    }
                }

                
                if(update_park.Location!=null)
                {
                    if(update_park.Location.Coodinates!=null)
                    {
                        exist_park.Location.Coodinates=update_park.Location.Coodinates;
                    }

                    if (update_park.Location.Street != null)
                    {
                        exist_park.Location.Street = update_park.Location.Street;
                    }

                    if (update_park.Location.City != null)
                    {
                        exist_park.Location.City = update_park.Location.City;
                    }

                    if (update_park.Location.PostalCode != null)
                    {
                        exist_park.Location.PostalCode = update_park.Location.PostalCode;
                    }

                }

                if(update_park.ParkDescription!=null)
                {
                    exist_park.ParkDescription = update_park.ParkDescription;
                }

                if (update_park.ParkName != null)
                {
                    exist_park.ParkName = update_park.ParkName;
                }

                if (update_park.ImageUrl != null)
                {
                    exist_park.ImageUrl = update_park.ImageUrl;
                }

                await _context.SaveChangesAsync();
                return Ok(exist_park);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpDelete("DeletePark/{id}")]
        public async Task<IActionResult> DeletePark(int id)
        {
            var park = await _context.Parks
                           .Include(p => p.Features)
                           .Include(p => p.Location)
                           .FirstOrDefaultAsync(p => p.ParkId == id);
            if (park == null)
            {
                return NotFound("Park not found");
            }

            try
            {
                _context.Parks.Remove(park);
                await _context.SaveChangesAsync();

                return Ok(park);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


    }
}
