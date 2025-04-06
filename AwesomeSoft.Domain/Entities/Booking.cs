using AwesomeSoft.Domain.Entities.Base;

namespace AwesomeSoft.Domain.Entities
{
    public class Booking : BaseModel
    {
        public string Day { get; set; } = string.Empty; // e.g., "Monday"
        public int SlotIndex { get; set; }
        public int BookerId { get; set; }
        public required Person Booker { get; set; }
        public int MeetingRoomId { get; set; }
        public MeetingRoom? MeetingRoom { get; set; }
    }
}
