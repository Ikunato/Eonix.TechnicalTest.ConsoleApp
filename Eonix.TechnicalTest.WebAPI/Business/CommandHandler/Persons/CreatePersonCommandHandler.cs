using Eonix.TechnicalTest.WebAPI.Business.Command.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.CommandHandler.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonOut>
    {
        private readonly IPersonService _personService;

        public CreatePersonCommandHandler(IPersonService service)
        => _personService = service;

        public async Task<PersonOut> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personService.CreatePersonAsync(request.CreatePersonIn);
            //TODO : Error handling
            return person;
        }
    }
}
