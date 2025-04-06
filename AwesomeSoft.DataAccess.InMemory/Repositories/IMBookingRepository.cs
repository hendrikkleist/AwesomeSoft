using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.InMemory.Repositories
{
    public class IMBookingRepository : IMGenericRepository<Booking>, IBookingRepository
    {
        public Task<bool> BookingExistsAsync(Booking booking)
        {
            return Task.FromResult(_items.Any(b => b.Day == booking.Day && b.SlotIndex == booking.SlotIndex));
        }

        public Dictionary<string, string[]> GetSchedule(int meetingRoomId)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string[] slots = new string[8]; // 8 time slots
            var schedule = new Dictionary<string, string[]>();
            foreach (var day in days)
            {
                var booked = _items
                    .Where(b => b.Day == day && b.MeetingRoomId == meetingRoomId)
                    .ToDictionary(b => b.SlotIndex, b => b.Booker);

                var daySlots = new string[8];
                for (int i = 0; i < 8; i++)
                {
                    daySlots[i] = booked.ContainsKey(i) ? $"{booked[i].FirstName} {booked[i].LastName}".Trim() : $"Available {i + 8} to {i + 9}";
                }

                schedule[day.ToString()] = daySlots;
            }

            return schedule;
        }
    }
}
