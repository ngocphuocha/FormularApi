using FormularApi.Data;
using FormularApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormularApi.Core.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
    {
    } 

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _context.Drivers.Where(x => x.Id < 100)
                .AsNoTracking().
                ToListAsync();
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
    public override async Task<Driver?> GetById(int id)
    {
        try
        {
            return await _context.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
    
    public async Task<Driver?> GetByDriverNumber(int driverNumber)
    {
        try
        {
            return await _context.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
}