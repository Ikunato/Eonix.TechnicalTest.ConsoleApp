namespace Eonix.TechnicalTest.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Person(string firstname, string lastname)
        {
            Id = Guid.NewGuid();
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
