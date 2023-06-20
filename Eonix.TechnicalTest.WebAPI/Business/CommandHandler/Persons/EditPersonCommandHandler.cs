using Eonix.TechnicalTest.WebAPI.Business.Command.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.CommandHandler.Persons
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, PersonOut>
    {
        private readonly IPersonService _personService;

        public EditPersonCommandHandler(IPersonService service)
        => _personService = service;

        public async Task<PersonOut> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        => await _personService.UpdatePersonAsync(request.UpdatePersonIn);
    }
}
