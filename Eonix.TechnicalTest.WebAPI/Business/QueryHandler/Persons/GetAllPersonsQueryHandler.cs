using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Business.Query.Persons;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.QueryHandler.Persons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonOut>>
    {
        private readonly IPersonService _personService;

        public GetAllPersonsQueryHandler(IPersonService service)
        => _personService = service;

        public async Task<IEnumerable<PersonOut>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        => await _personService.GetAllPersonsAsync(request.AllPersonsIn);
    }
}
