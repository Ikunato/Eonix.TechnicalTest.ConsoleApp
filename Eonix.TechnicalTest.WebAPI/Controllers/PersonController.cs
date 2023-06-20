using Eonix.TechnicalTest.WebAPI.Business.Command.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.DtoIn;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Query.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eonix.TechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons([FromQuery] AllPersonsIn dto)
        {
            var persons = await _mediator.Send(new GetAllPersonsQuery { AllPersonsIn = dto });
            if (!persons.Any()) return NotFound();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery
            {
                Id = id
            });

            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost("Create")]
        public IActionResult CreatePerson([FromBody] CreatePersonIn dto)
        {
            var person = _mediator.Send(new CreatePersonCommand { CreatePersonIn = dto });

            return Ok(person);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditPerson([FromBody] UpdatePersonIn dto)
        {
            var person = await _mediator.Send(new EditPersonCommand { UpdatePersonIn = dto });
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var person = await _mediator.Send(new DeletePersonCommand { Id = id });
            if (person == null) return NotFound();
            return Ok(person);
        }
    }
}
