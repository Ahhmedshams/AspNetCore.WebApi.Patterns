using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.WebAPI.Queries.DriverQuery
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        public GetDriverQuery(Guid driverID)
        {
            DriverID = driverID;
        }

        public Guid DriverID { get; }


    }
}
