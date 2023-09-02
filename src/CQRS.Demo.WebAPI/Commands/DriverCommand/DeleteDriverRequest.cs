using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.WebAPI.Commands.DriverCommand
{
    public class DeleteDriverRequest : IRequest<bool>
    {
        public Guid DriverId { get; }
        public DeleteDriverRequest(Guid driverId)
        {
            DriverId = driverId;
        }
    }


}
