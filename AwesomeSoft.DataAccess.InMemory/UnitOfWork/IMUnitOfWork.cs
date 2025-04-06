using AwesomeSoft.DataAccess.InMemory.Repositories;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.InMemory.UnitOfWork
{
    public class IMUnitOfWork : IUnitOfWork
    {
        public IMUnitOfWork()
        {
            People = new IMPeopleRepository();
            MeetingRooms = new IMMeetingRoomRepository();
            Bookings = new IMBookingRepository();
        }

        public IPeopleRepository People { get; }
        public IMeetingRoomRepository MeetingRooms { get; }
        public IBookingRepository Bookings { get; }

        public int Complete()
        {
            // 0 is bad
            // Anything else 0 is good
            // Since we're dealing with in memory database, all things should always be good
            return 1;
        }

        public void Dispose()
        {
            // Do nothing
        }
    }
}
