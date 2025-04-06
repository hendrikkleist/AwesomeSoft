using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.Domain.Entities.Base;
using AwesomeSoft.Domain.Interfaces;
using System.Linq.Expressions;

namespace AwesomeSoft.DataAccess.EntityFramework.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            var addEntity = entity as BaseModel;
            addEntity.Created = DateTime.UtcNow;
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var addEntity = entity as BaseModel;
                addEntity.Created = DateTime.Now;
            }
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(int id, T entity)
        {
            var updateEntity = entity as BaseModel;
            updateEntity.Updated = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
        }
    }
}
