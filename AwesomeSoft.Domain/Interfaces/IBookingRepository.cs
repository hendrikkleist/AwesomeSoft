using AwesomeSoft.Domain.Entities;

namespace AwesomeSoft.Domain.Interfaces;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Dictionary<string, string[]> GetSchedule();

    Task<bool> BookingExistsAsync(Booking booking);
}
