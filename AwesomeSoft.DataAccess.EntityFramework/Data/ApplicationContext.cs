using AwesomeSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSoft.DataAccess.EntityFramework.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
