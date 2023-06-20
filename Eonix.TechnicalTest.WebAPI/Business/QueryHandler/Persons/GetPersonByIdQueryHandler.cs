using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Query.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.QueryHandler.Persons
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonOut>
    {
        private readonly IPersonService _personService;

        public GetPersonByIdQueryHandler(IPersonService service)
        => _personService = service;

        public Task<PersonOut> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        => _personService.GetPersonByIdAsync(request.Id);
    }
}
