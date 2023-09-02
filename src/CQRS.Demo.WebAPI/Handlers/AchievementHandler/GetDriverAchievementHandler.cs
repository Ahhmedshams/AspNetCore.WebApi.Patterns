using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Queries.AchievementQuery;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.AchievementHandler
{
    public class GetDriverAchievementHandler : IRequestHandler<GetDriverAchievementQuery, DriverAchievementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverAchievementResponse> Handle(GetDriverAchievementQuery request, CancellationToken cancellationToken)
        {
            var driverAchivement = await _unitOfWork.Achievements.GetDriverAchievementAsync(request.DriverId);
            if (driverAchivement == null)
                return null;
            else
            return _mapper.Map<DriverAchievementResponse>(driverAchivement); 
        }
    }
}
