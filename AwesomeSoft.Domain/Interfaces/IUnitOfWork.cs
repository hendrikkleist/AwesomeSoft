namespace AwesomeSoft.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPeopleRepository People {  get; }
    IMeetingRoomRepository MeetingRooms { get; }
    int Complete();
}
