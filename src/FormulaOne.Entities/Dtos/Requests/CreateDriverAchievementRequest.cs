using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Requests
{
    public class CreateDriverAchievementRequest
    {
        public Guid DriverId { get; set; }
        public int WorldChampoinship { get; set; }
        public int Wins { get; set; }
        public int PolePosition { get; set; }
        public int FasterLap { get; set; }

    }
}
