using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Commands.AchievementCommand;
using FormulaOne.WebAPI.Commands.DriverCommand;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.AchievementHandler
{
    public class CreateAchievementHandler : IRequestHandler<CreateAchievementRequest, Achievement>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Achievement> Handle(CreateAchievementRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Achievement>(request.DriverAchievement);
            await _unitOfWork.Achievements.AddAsync(result);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
