using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.WebAPI.Commands.DriverCommand;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.DriverHandler
{
    public class UpdateDriverInfoHandler : IRequestHandler<UpdateDriverInfoRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
        {

            var driver = _mapper.Map<Driver>(request.Driver);
            await _unitOfWork.Drivers.UpdateAsync(driver);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
