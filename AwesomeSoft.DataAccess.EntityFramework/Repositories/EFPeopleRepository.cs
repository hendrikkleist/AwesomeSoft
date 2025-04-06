using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories;

public class EFPeopleRepository : EFGenericRepository<Person>, IPeopleRepository
{
    public EFPeopleRepository(ApplicationContext context) : base(context)
    {
    }
    
    public List<Booking> GetBookings(int personId)
    {
        var person = _context.People
            .Include(p => p.Bookings)
            .FirstOrDefault(p => p.Id == personId)
            ;
        return person.Bookings;
    }
}
