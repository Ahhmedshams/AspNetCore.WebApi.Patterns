using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Commands.DriverCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Handlers.DriverHandler
{
    public class GetDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
        {
              var driver = _mapper.Map<Driver>(request.DriverRequest);
              await _unitOfWork.Drivers.AddAsync(driver);
              await _unitOfWork.CompleteAsync();
            return _mapper.Map<GetDriverResponse>(driver);
        }
    }
}
