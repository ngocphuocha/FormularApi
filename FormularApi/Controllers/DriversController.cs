
using FormularApi.Core;
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
        private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Drivers.All());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost] 
        public async Task<IActionResult> AddDriver(Driver driver)
        {
           _unitOfWork.Drivers.Add(driver);
           await _unitOfWork.CompleteAsync();
           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null) return NotFound();

            _unitOfWork.Drivers.Delete(driver);

            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            var existDriver = await _unitOfWork.Drivers.GetById(id);

            if(existDriver == null) return NotFound();

            _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync(); 
            return NoContent();
        } 
    }
}
