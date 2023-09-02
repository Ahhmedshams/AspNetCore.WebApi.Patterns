using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Queries.DriverQuery;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.DriverHandler
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetByIdAsync(request.DriverID);
            if (driver == null)
                return null;

            var result = _mapper.Map<GetDriverResponse>(driver);
            return result;
        }
    }
}
