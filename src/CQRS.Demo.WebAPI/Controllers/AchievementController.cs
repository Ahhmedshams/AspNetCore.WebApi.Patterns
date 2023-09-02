using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : BaseController
    {
        public AchievementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchivement = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
            if(driverAchivement ==null)
                return NotFound();

            var result = _mapper.Map<DriverAchievementResponse>(driverAchivement);
            return Ok(result);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.Achievements.AddAsync(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid)
                   return BadRequest(ModelState);

            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.Achievements.UpdateAsync(result);
            await _unitOfWork.CompleteAsync();  
            return NoContent();  
        }
    }
}
