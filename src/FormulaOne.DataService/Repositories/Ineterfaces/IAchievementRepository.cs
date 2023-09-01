using FormulaOne.DataService.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Ineterfaces
{
    public interface IAchievementRepository:IGenericRepository<Achievement>
    {
        Task<Achievement?> GetDriverAchievementAsync(Guid id);
    }
}
