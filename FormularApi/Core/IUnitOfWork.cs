namespace FormularApi.Core;

public interface IUnitOfWork
{
    IBookingRepository Booking { get; }
    IDriverRepository Drivers { get; }
   
    Task CompleteAsync();
}