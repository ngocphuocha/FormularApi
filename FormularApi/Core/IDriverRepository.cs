using FormularApi.Models;

namespace FormularApi.Core;

public interface IDriverRepository: IGenericRepository<Driver>
{
    Task<Driver?> GetByDriverNumber(int driverNumber);
    
}