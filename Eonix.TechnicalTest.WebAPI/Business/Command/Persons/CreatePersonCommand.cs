using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.DtoIn;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using MediatR;

namespace Eonix.TechnicalTest.WebAPI.Business.Command.Persons
{
    public record CreatePersonCommand : IRequest<PersonOut>
    {
        public CreatePersonIn CreatePersonIn { get; set; }
    }
}
