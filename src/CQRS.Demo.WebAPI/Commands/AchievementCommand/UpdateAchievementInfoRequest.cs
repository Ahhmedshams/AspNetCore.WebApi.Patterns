using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.WebAPI.Commands.AchievementCommand
{
    public class UpdateAchievementInfoRequest : IRequest<bool>
    {
        public UpdateDriverAchievementRequest Achievement { get; }

        public UpdateAchievementInfoRequest(UpdateDriverAchievementRequest achievement)
        {
            Achievement = achievement;
        }
    }
}
