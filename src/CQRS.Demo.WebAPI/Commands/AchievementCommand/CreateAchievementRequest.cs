using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.WebAPI.Commands.AchievementCommand
{
    public class CreateAchievementRequest : IRequest<Achievement>
    {
        public CreateDriverAchievementRequest DriverAchievement { get; }

        public CreateAchievementRequest(CreateDriverAchievementRequest driverAchievement)
        {
            DriverAchievement = driverAchievement;
        }
    }
}
