using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Ineterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IDriverRepository Drivers { get;  }

        public IAchievementRepository Achievements { get;  }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");
            Drivers = new DriverRepository(logger, _context);
            Achievements = new AchievementRepository(logger, _context);
        }

        public async Task<bool> CompleteAsync()
        {
           var result= await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
