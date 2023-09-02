using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.WebAPI.Commands.DriverCommand
{
    public class UpdateDriverInfoRequest : IRequest<bool>
    {
        public UpdateDriverRequest Driver { get; }

        public UpdateDriverInfoRequest(UpdateDriverRequest driver)
        {
            Driver = driver;
        }
    }
}
