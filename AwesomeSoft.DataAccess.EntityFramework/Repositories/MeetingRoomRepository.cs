using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories;

public class MeetingRoomRepository : GenericRepository<MeetingRoom>, IMeetingRoomRepository
{
    public MeetingRoomRepository(ApplicationContext context) : base(context)
    {
    }
}
