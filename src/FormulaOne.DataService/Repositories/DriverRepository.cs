using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class DriverRepository : GenaricRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ILogger logger, ApplicationDbContext context) : base(logger, context)
        {
        }


        public override async Task<IEnumerable<Driver>> GetAllAsync()
        {
            try
            {
                    return await _dbSet.Where(driver=>driver.Status == 1 )
                                    .AsNoTracking()
                                    .AsSplitQuery()
                                    .OrderBy(e=>e.AddedDate)
                                    .ToListAsync();

            }catch(Exception ex)
            {
                logger.LogError(ex,"{Repo} GetAllAsync function erorr",typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} DeleteAsync function erorr", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> UpdateAsync(Driver driver)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.DriverNumber = driver.DriverNumber;
                result.FirstName = driver.FirstName;
                result.LastName = driver.LastName;
                result.DateOfBirth = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} DeleteAsync function erorr", typeof(DriverRepository));
                throw;
            }
        }
    }
}
