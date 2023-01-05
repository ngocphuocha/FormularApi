using FormularApi.Data;
using FormularApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace FormularApi.Core.Repositories;
public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(ApiDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<bool> AddNewBooking(Booking entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} add new booking error", typeof(BookingRepository));
            return false;
        }
    }

    public async Task<IEnumerable<Booking>> GetBookingByTargetLocation(string targetAddress)
    {
        try
        {
            var bookings = from b in _context.Bookings
                           where EF.Functions.Like(b.TargetAddress, $"%{targetAddress}%")
                           select b;

            return await bookings.ToListAsync(); 
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} add new booking error", typeof(BookingRepository));
            return new List<Booking>();
        }
    }
}
