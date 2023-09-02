using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Drivers : BaseController
    {
        public Drivers(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _unitOfWork.Drivers.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GetDriverResponse>>(drivers));
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetByIdAsync(driverId);
            if (driver == null)
                return NotFound();

            var result = _mapper.Map<GetDriverResponse>(driver);
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.AddAsync(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.UpdateAsync(result);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetByIdAsync(driverId);
            if (driver == null)
                return NotFound();

            await _unitOfWork.Drivers.DeleteAsync(driverId);
            await _unitOfWork.CompleteAsync();
            return NoContent();

        }
    }
}
