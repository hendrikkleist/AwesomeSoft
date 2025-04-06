using AwesomeSoft.Domain.Entities.Base;

namespace AwesomeSoft.Domain.Entities;

public class MeetingRoom : BaseModel
{
    public int RoomNumber { get; set; }

    public ICollection<Booking>? Bookings { get; set; }
}
