using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Commands.DriverCommand
{
    public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
    {
        public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }

        public CreateDriverRequest DriverRequest { get; }

    }
}
