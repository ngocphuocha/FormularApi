
using FormularApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
                Id = 1,
                Name = "phuoc",
                Team = "Mescedes",
                DriverNumber = 44,
            },
            new Driver()
            {
                Id = 2,
                Name = "Phuoc 2",
                Team = "Lamboghini",
                DriverNumber = 30
            },
             new Driver()
             {
                Id = 3,
                Name = "Phuoc 3",
                Team = "Ferarri",
                DriverNumber = 99
             }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_drivers.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            return Ok(_drivers);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);

            if (driver == null) return NotFound();

            _drivers.Remove(driver);
            return NoContent();
        }
    }
}
