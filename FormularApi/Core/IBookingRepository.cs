using FormularApi.Models;

namespace FormularApi.Core;
public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<bool> AddNewBooking(Booking entity);
}

