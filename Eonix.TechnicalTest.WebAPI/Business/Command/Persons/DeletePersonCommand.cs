using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.Command.Persons
{
    public record DeletePersonCommand : IRequest<PersonOut>
    {
        public Guid Id { get; set; }
    }
}
