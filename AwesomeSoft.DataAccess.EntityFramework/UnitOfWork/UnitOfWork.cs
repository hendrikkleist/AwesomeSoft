using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.DataAccess.EntityFramework.Repositories;
using AwesomeSoft.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeSoft.DataAccess.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            People = new PeopleRepository(_context);
        }

        public IPeopleRepository People { get; private set; }

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
