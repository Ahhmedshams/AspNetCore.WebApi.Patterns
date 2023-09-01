using AutoMapper;
using FormulaOne.DataService.Repositories.Ineterfaces;
using Microsoft.AspNetCore.Http;
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
    }
}
