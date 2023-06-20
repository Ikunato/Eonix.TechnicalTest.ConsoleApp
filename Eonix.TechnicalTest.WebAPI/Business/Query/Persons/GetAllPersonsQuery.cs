using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.DtoIn;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.Query.Persons
{
    public record GetAllPersonsQuery : IRequest<IEnumerable<PersonOut>>
    {
        public AllPersonsIn AllPersonsIn { get; set; }
    }
}
