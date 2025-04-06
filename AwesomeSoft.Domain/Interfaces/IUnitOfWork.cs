namespace AwesomeSoft.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPeopleRepository People {  get; }
    IMeetingRoomRepository MeetingRooms { get; }
    IBookingRepository Bookings { get; }
    int Complete();
}
