using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories;

public class EFMeetingRoomRepository : EFGenericRepository<MeetingRoom>, IMeetingRoomRepository
{
    public EFMeetingRoomRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> RoomExistsAsync(int meetingRoomId)
    {
        return await _context.MeetingRooms.AnyAsync(m => m.Id == meetingRoomId);
    }
}
