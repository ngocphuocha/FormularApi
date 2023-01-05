using FormularApi.Core;
using FormularApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FormularApi.Controllers
{
    [EnableCors("GrabBookingPolicy")]
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
            return Ok(await _unitOfWork.Bookings.All());
        }
        [HttpGet("/target-location")]
        public async Task<IActionResult> GetTripByTargetLocation(string targetLocation)
        {
            return Ok(await _unitOfWork.Bookings.GetBookingByTargetLocation(targetLocation));
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            await _unitOfWork.Bookings.AddNewBooking(booking);
            await _unitOfWork.CompleteAsync();
            return Ok(booking);
        }
    }
}
