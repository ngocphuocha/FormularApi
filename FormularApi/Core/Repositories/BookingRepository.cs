using FormularApi.Data;
using FormularApi.Models;

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
}
