using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.DataAccess.EntityFramework.Repositories;
using AwesomeSoft.Domain.Interfaces;

namespace AwesomeSoft.DataAccess.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            People = new PeopleRepository(_context);
            MeetingRooms = new MeetingRoomRepository(_context);
        }

        public IPeopleRepository People { get; private set; }
        public IMeetingRoomRepository MeetingRooms { get; private set; }

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
