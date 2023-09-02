using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Ineterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementRepository : GenaricRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(ILogger logger, ApplicationDbContext context) : base(logger, context)
        {
        }


        public async Task<Achievement?> GetDriverAchievementAsync(Guid id)
        {
            try
            {              
                 return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == id); ;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetDriverAchievementAsync function erorr", typeof(AchievementRepository));
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
                logger.LogError(ex, "{Repo} DeleteAsync function erorr", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> UpdateAsync(Achievement achievement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.FasterLap = achievement.FasterLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampoinship = achievement.WorldChampoinship;
                result.DriverId = achievement.DriverId;
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} DeleteAsync function erorr", typeof(AchievementRepository));
                throw;
            }
        }


    }
}
