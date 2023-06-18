using Eonix.TechnicalTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eonix.TechnicalTest.WebAPI.Infrastructure.Persistance
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public string DbPath { get; }

        public PersonDbContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "person.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
