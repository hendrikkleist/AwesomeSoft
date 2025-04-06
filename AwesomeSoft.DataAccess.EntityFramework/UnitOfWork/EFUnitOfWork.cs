using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.DataAccess.EntityFramework.Repositories;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.EntityFramework.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context;
            People = new EFPeopleRepository(_context);
            MeetingRooms = new EFMeetingRoomRepository(_context);
            Bookings = new EFBookingRepository(_context);
        }

        public IPeopleRepository People { get; private set; }
        public IMeetingRoomRepository MeetingRooms { get; private set; }
        public IBookingRepository Bookings { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
