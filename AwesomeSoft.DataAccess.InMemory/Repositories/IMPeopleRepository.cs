using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.InMemory.Repositories;

public class IMPeopleRepository : IMGenericRepository<Person>, IPeopleRepository
{
    public List<Booking> GetBookings(int personId)
    {
        var person = GetById(personId);
        return person.Bookings;
    }
}
