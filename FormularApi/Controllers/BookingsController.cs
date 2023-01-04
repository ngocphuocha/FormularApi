using FormularApi.Core;
using FormularApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Booking.All());
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            await _unitOfWork.Booking.AddNewBooking(booking);
            await _unitOfWork.CompleteAsync();
            return Ok(booking);
        }
    }
}
