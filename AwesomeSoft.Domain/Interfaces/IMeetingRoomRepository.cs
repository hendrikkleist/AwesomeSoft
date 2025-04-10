﻿using AwesomeSoft.Domain.Entities;

namespace AwesomeSoft.Domain.Interfaces
{
    public interface IMeetingRoomRepository : IGenericRepository<MeetingRoom>
    {
        Task<bool> RoomExistsAsync(int meetingRoomId);
    }
}
