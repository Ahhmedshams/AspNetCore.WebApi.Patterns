using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.WebAPI.Commands.DriverCommand;
using FormulaOne.WebAPI.Queries.DriverQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Drivers : BaseController
    {
        public Drivers(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var query = new GetAllDriverQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);
            
            if (result == null)
                return NotFound();
            else
                 return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = new CreateDriverInfoRequest(driver);
               
            var result = await _mediator.Send(command);
            

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var command = new UpdateDriverInfoRequest(driver);
            var result = await _mediator.Send(command);

            if(result == true) 
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
           
            var command = new DeleteDriverRequest(driverId);
            var result = await _mediator.Send(command);
            return result? NoContent(): NotFound();
          
        }
    }
}
