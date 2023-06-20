using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.Query.Persons
{
    public record GetPersonByIdQuery : IRequest<PersonOut>
    {
        public Guid Id { get; set; }
    }
}
