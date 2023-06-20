using Eonix.TechnicalTest.Business.Dto.Person;
using Microsoft.AspNetCore.Mvc;

namespace Eonix.TechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id}")]
        public PersonByIdOut Get(Guid Id)
        {

        }
    }
}
