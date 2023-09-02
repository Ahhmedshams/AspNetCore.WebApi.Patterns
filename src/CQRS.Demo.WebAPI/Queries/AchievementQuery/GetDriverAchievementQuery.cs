using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.WebAPI.Queries.AchievementQuery
{
    public class GetDriverAchievementQuery:IRequest<DriverAchievementResponse>
    {
        public Guid DriverId { get; set; }

        public GetDriverAchievementQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
