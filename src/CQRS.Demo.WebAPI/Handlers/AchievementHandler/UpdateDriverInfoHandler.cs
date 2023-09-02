using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.WebAPI.Commands.AchievementCommand;
using FormulaOne.WebAPI.Commands.DriverCommand;
using MediatR;

namespace FormulaOne.WebAPI.Handlers.AchievementHandler
{
    public class UpdateDriverInfoHandler : IRequestHandler<UpdateAchievementInfoRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAchievementInfoRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Achievement>(request.Achievement);
            await _unitOfWork.Achievements.UpdateAsync(result);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
