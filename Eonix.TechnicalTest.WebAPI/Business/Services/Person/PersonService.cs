using Eonix.TechnicalTest.Domain;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.DtoIn;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.Out;
using Eonix.TechnicalTest.WebAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Eonix.TechnicalTest.WebAPI.Business.Services
{
    public interface IPersonService
    {
        public Task<IEnumerable<PersonOut>> GetAllPersonsAsync(AllPersonsIn dto);
        public Task<PersonOut> GetPersonByIdAsync(Guid id);
        public Task<PersonOut> CreatePersonAsync(CreatePersonIn dto);
        public Task<PersonOut> UpdatePersonAsync(UpdatePersonIn dto);
        public Task<PersonOut> DeletePersonAsync(Guid id);
    }

    public record PersonService : IPersonService
    {
        private PersonDbContext Context { get; }

        public PersonService(PersonDbContext db)
        {
            Context = db;
        }

        public async Task<IEnumerable<PersonOut>> GetAllPersonsAsync(AllPersonsIn dto)
        {
            List<PersonOut> result = await Context.Persons.Select(x => 
                new PersonOut 
                { 
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                })
                .Where(person => string.IsNullOrEmpty(dto.Firstname) || person.Firstname.Contains(dto.Firstname))
                .Where(person => string.IsNullOrEmpty(dto.Lastname) ||  person.Lastname.Contains(dto.Lastname))
                .ToListAsync();

            return result;
        }
        public async Task<PersonOut> GetPersonByIdAsync(Guid id)
        {
            var person = await Context.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null) return null;

            return new PersonOut
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
            };
        }

        public async Task<PersonOut> CreatePersonAsync(CreatePersonIn dto)
        {
            if (string.IsNullOrEmpty(dto.Firstname) || string.IsNullOrEmpty(dto.Lastname)) return null;
            var person = new Person(dto.Firstname, dto.Lastname);

            try
            {
                await Context.Persons.AddAsync(person);
                await Context.SaveChangesAsync();

                return new PersonOut
                {
                    Id = person.Id,
                    Firstname = person.Firstname,
                    Lastname= person.Lastname,
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<PersonOut> UpdatePersonAsync(UpdatePersonIn dto)
        {
            var personToBeUpdated = await Context.Persons.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (personToBeUpdated == null) return null;

            personToBeUpdated.Firstname = string.IsNullOrEmpty(dto.Firstname) ? personToBeUpdated.Firstname : dto.Firstname;
            personToBeUpdated.Lastname = string.IsNullOrEmpty(dto.Lastname) ? personToBeUpdated.Lastname : dto.Lastname;

            await Context.SaveChangesAsync();

            return new PersonOut
            {
                Id = personToBeUpdated.Id,
                Firstname = personToBeUpdated.Firstname,
                Lastname = personToBeUpdated.Lastname,
            };
        }

        public async Task<PersonOut> DeletePersonAsync(Guid id)
        {
            var personToDelete = await Context.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (personToDelete == null) return null;

            Context.Persons.Remove(personToDelete);
            await Context.SaveChangesAsync();

            return new PersonOut 
            { 
                Id = personToDelete.Id, 
                Firstname = personToDelete.Firstname, 
                Lastname = personToDelete.Lastname 
            };
        }

    }
}
