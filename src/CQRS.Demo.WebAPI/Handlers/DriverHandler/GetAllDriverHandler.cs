using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Queries.DriverQuery;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.DriverHandler
{
    public class GetAllDriverHandler : IRequestHandler<GetAllDriverQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriverQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.Drivers.GetAllAsync();
            return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        }
    }
}
