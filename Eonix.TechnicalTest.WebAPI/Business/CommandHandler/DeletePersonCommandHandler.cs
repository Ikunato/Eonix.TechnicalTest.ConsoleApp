using Eonix.TechnicalTest.WebAPI.Business.Command.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.CommandHandler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, PersonOut>
    {
        private readonly IPersonService _personService;

        public DeletePersonCommandHandler(IPersonService service)
        => _personService = service;

        public async Task<PersonOut> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        => await _personService.DeletePersonAsync(request.Id);
    }
}
