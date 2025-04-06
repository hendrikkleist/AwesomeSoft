using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.InMemory.Repositories;

public class IMMeetingRoomRepository : IMGenericRepository<MeetingRoom>, IMeetingRoomRepository
{
    public Task<bool> RoomExistsAsync(int meetingRoomId)
    {
        var meetingRoom = GetById(meetingRoomId);
        if (meetingRoom is not null)
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
