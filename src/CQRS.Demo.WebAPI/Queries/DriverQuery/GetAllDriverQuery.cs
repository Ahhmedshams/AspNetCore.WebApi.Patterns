using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.WebAPI.Queries.DriverQuery
{
    public class GetAllDriverQuery : IRequest<IEnumerable<GetDriverResponse>>
    {

    }
}
