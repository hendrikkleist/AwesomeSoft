using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories;

public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
{
    public PeopleRepository(ApplicationContext context) : base(context)
    {
    }
}
