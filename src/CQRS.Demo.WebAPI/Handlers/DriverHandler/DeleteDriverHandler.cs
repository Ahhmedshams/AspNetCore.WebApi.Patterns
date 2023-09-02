using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.WebAPI.Commands.DriverCommand;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.DriverHandler
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetByIdAsync(request.DriverId);
            if (driver == null)
                return false;

            await _unitOfWork.Drivers.DeleteAsync(request.DriverId);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
