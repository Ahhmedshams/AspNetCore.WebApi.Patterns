using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet;

public class Achievement: BaseEntity
{
   
    public int RaceWins { get; set; }
    public int PolePosition { get; set; }
    public int FasterLap { get; set; }
    public int WorldChampoinship { get; set; }
    public Guid DriverId { get; set; }

    public Driver Driver { get; set; } 
}
