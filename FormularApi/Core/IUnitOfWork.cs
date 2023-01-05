namespace FormularApi.Core;

public interface IUnitOfWork
{
    IBookingRepository Bookings { get; }
    IDriverRepository Drivers { get; }
   
    Task CompleteAsync();
}