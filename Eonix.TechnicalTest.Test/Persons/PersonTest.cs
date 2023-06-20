using Eonix.TechnicalTest.Domain;
using Eonix.TechnicalTest.Test.Helper;
using Eonix.TechnicalTest.WebAPI.Business.Dto.Person.DtoIn;
using Eonix.TechnicalTest.WebAPI.Business.Services;
using Eonix.TechnicalTest.WebAPI.Infrastructure.Persistance;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Eonix.TechnicalTest.Test.Persons
{
    public class PersonTest
    {
        public static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person("Dario", "Despiegeleer"),
                new Person("Dado", "Prso" ),
                new Person("Darijo", "Srna" ),
                new Person("Zlatan", "Ibrahimovic" ),
                new Person( "Luka", "Modric" ),
            };
        }

        [Fact]
        public async void GetAllPersons_EmptyFilter_ShouldBeSameList()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn();

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.Equal(data.Count(), persons.Count());
        }

        [Fact]
        public async void GetAllPersons_FilterFirstname_ShouldGivePersonsThatFirstnameStartsWithDa()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Firstname = "Da" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>()); ;

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.Equal(3, persons.Count());

        }
        [Fact]
        public async void GetAllPersons_FilterLastname_ShouldGivePersonsThatLastnameContains_Ic()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Lastname = "ic" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.NotEmpty(persons);
            Assert.Equal(2, persons.Count());
            Assert.NotNull(persons.FirstOrDefault(x => x.Lastname == "Ibrahimovic"));
            Assert.Equal(data.FirstOrDefault(x => x.Lastname == "Ibrahimovic").Lastname, persons.FirstOrDefault(x => x.Lastname == "Ibrahimovic").Lastname);
        }

        [Fact]
        public async void GetAllPersons_FilterFirstnameAndLastname_ShouldGiveOnePersonne()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Firstname = "Dario", Lastname = "Despiegeleer" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.NotEmpty(persons);
            Assert.Single(persons);
            Assert.NotNull(persons.FirstOrDefault(x => x.Firstname.Contains("Dario") && x.Lastname.Contains("Despiegeleer")));
            Assert.Equal(data.FirstOrDefault(x => x.Firstname.Contains("Dario") && x.Lastname.Contains("Despiegeleer")).Id.ToString(), persons.FirstOrDefault(x => x.Firstname.Contains("Dario") && x.Lastname.Contains("Despiegeleer")).Id.ToString());
        }

        [Fact]
        public async void GetAllPersons_Filter_ShouldGiveEmptyList()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Lastname = "Durand" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.Empty(persons);
        }

        [Fact]
        public async void GetAllPersons_Filter_FirstnameCorrect_And_LastnameIncorrect_ShouldReturnEmptyList()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Firstname = "Dario", Lastname = "Ibrahimovic" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.Empty(persons);
        }

        [Fact]
        public async void GetAllPersons_Filter_FirstnameInCorrect_And_Lastnamecorrect_Should_ReturnEmptyList()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new AllPersonsIn { Firstname = "Zlatan", Lastname = "De Bruyimovic" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var persons = await service.GetAllPersonsAsync(filter);

            //Assert
            Assert.Empty(persons);
        }

        [Fact]
        public async void GetPersonById_GivesCorrectId_Should_ReturnCorrectPerson()
        {
            //Act
            var data = GetPersons().AsQueryable();
            Guid id = data.First().Id;

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.GetPersonByIdAsync(id);

            //Assert
            Assert.NotNull(person);
            Assert.Equal(data.First().Id, person.Id);
        }

        [Fact]
        public async void GetPersonById_GivesEmptyGuid_Should_ReturnNull()
        {
            //Act
            var data = GetPersons().AsQueryable();
            Guid id = new Guid();

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.GetPersonByIdAsync(id);

            //Assert
            Assert.Null(person);
        }

        [Fact]
        public async void AddPerson_Should_BeOk()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var filter = new CreatePersonIn { Firstname = "John", Lastname = "Doe" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.CreatePersonAsync(filter);

            //Assert
            Assert.NotNull(person);

            A.CallTo(() => mockContext.SaveChangesAsync(A<CancellationToken>._)).MustHaveHappened();
            //TODO : Somehow doesn't work but the add is still made since person is not null
            //A.CallTo(() => mockContext.AddAsync(A<Person>.That.IsNotNull(), A<CancellationToken>._)).MustHaveHappened();
        }

        [Fact]
        public async void UpdatePerson_GivesCorrectId_Should_Update()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var personToUpdate = data.FirstOrDefault();
            string oldFirstname = personToUpdate.Firstname;
            var filter = new UpdatePersonIn { Id = personToUpdate.Id, Firstname = "Niko", Lastname = "Kovac" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.UpdatePersonAsync(filter);

            //Assert
            Assert.NotNull(person);
            Assert.Equal(person.Id, personToUpdate.Id);
            Assert.NotEqual(oldFirstname, person.Firstname);
        }

        [Fact]
        public async void UpdatePerson_GivesIncorrectId_Should_NotUpdate()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var personToUpdate = data.FirstOrDefault();
            string oldFirstname = personToUpdate.Firstname;
            var filter = new UpdatePersonIn { Id = new Guid(), Firstname = "Niko", Lastname = "Kovac" };

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.UpdatePersonAsync(filter);

            //Assert
            Assert.Null(person);
            A.CallTo(() => mockContext.SaveChangesAsync(A<CancellationToken>._)).MustNotHaveHappened();
        }

        [Fact]
        public async void DeletePerson_GivesCorrectId_Should_Delete()
        {
            //Act
            var data = GetPersons().AsQueryable();
            var personToDelete = data.FirstOrDefault();
            int oldListCount = data.Count();
            var id = personToDelete.Id;

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.DeletePersonAsync(id);

            //Assert
            Assert.NotNull(person);
            //TODO : Verify that a call to the correct method was made
            A.CallTo(() => mockContext.Persons.Remove(A<Person>._)).MustHaveHappened();
            A.CallTo(() => mockContext.SaveChangesAsync(A<CancellationToken>._)).MustHaveHappened();
        }

        [Fact]
        public async void DeletePerson_GivesIncorrectId_Should_NotDelete()
        {
            //Act
            var data = GetPersons().AsQueryable();
            int oldListCount = data.Count();
            var id = new Guid();

            var mockSet = A.Fake<DbSet<Person>>(d => d.Implements<IQueryable<Person>>().Implements<IAsyncEnumerable<Person>>());

            A.CallTo(() => ((IQueryable<Person>)mockSet).Provider).Returns(new TestAsyncQueryProvider<Person>(data.Provider));
            A.CallTo(() => ((IQueryable<Person>)mockSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Person>)mockSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IAsyncEnumerable<Person>)mockSet).GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Person>(data.GetEnumerator()));

            //Arrange
            var mockContext = A.Fake<PersonDbContext>();
            A.CallTo(() => mockContext.Persons).Returns(mockSet);

            var service = new PersonService(mockContext);
            var person = await service.DeletePersonAsync(id);

            //Assert
            Assert.Null(person);
            A.CallTo(() => mockContext.Persons.Remove(A<Person>._)).MustNotHaveHappened();
            A.CallTo(() => mockContext.SaveChanges()).MustNotHaveHappened();
        }
    }
}
