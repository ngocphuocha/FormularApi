namespace FormularApi.Core;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    Task CompleteAsync();
}