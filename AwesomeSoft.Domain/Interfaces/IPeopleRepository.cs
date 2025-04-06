using AwesomeSoft.Domain.Entities;

namespace AwesomeSoft.Domain.Interfaces;

public interface IPeopleRepository : IGenericRepository<Person>
{
    List<Booking> GetBookings(int personId);
}
