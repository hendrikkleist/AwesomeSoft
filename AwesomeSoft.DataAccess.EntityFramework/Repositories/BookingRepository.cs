using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> BookingExistsAsync(Booking booking)
    {
        return await _context.Bookings.AnyAsync(b => b.Day == booking.Day && b.SlotIndex == booking.SlotIndex);
    }

    public Dictionary<string, string[]> GetSchedule(int meetingRoomId)
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        string[] slots = new string[8]; // 8 time slots
        var schedule = new Dictionary<string, string[]>();

        foreach (var day in days)
        {
            var booked = _context.Bookings
                .Include(b => b.Booker)
                .Where(b => b.Day == day && b.MeetingRoomId == meetingRoomId)
                .ToDictionary(b => b.SlotIndex, b => b.Booker);

            var daySlots = new string[8];
            for (int i = 0; i < 8; i++)
            {
                daySlots[i] = booked.ContainsKey(i) ? $"{booked[i].FirstName} {booked[i].LastName}".Trim() : $"Available {i+8} to {i + 9}";
            }

            schedule[day.ToString()] = daySlots;
        }

        return schedule;
    }
}
