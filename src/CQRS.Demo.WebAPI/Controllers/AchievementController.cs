using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOne.WebAPI.Commands.AchievementCommand;
using FormulaOne.WebAPI.Commands.DriverCommand;
using FormulaOne.WebAPI.Queries.AchievementQuery;
using FormulaOne.WebAPI.Queries.DriverQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : BaseController
    {
        public AchievementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var query = new GetDriverAchievementQuery(driverId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var command = new CreateAchievementRequest(achievement);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid)
                   return BadRequest(ModelState);

            var command = new UpdateAchievementInfoRequest(achievement);
            var result = await _mediator.Send(command);

            if (result == true)
                return NoContent();
            else
                return BadRequest();
        }
    }
}
