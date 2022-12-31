
using FormularApi.Data;
using FormularApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DriversController(ApiDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Drivers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost] 
        public async Task<IActionResult> AddDriver(Driver driver)
        {
           _context.Drivers.Add(driver);
           await _context.SaveChangesAsync();

           return Ok(await _context.Drivers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null) return NotFound();

            _context.Drivers.Remove(driver);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            var exitstDriver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

            if(exitstDriver == null) return NotFound();

            exitstDriver.Name = driver.Name;
            exitstDriver.Team = driver.Team;
            exitstDriver.DriverNumber = driver.DriverNumber;

            await _context.SaveChangesAsync();
                
            return NoContent();
        } 
    }
}
