using AwesomeSoft.Domain.Entities.Base;
using AwesomeSoft.Domain.Interfaces;
using System.Linq.Expressions;

namespace AwesomeSoft.DataAccess.InMemory.Repositories
{
    public class IMGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly List<T> _items = new();
        public void Add(T entity)
        {
            var addEntity = entity as BaseModel;
            addEntity.Created = DateTime.UtcNow;
            _items.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var addEntity = entity as BaseModel;
                addEntity.Created = DateTime.Now;
            }
            _items.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _items.Where(expression.Compile());
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(i => (i as BaseModel).Id == id);
        }

        public void Remove(T entity)
        {
            _items.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                _items.Remove(entity);
            }
        }

        public void Update(int id, T entity)
        {
            var index = _items.IndexOf(entity);
            var updateEntity = entity as BaseModel;
            updateEntity.Updated = DateTime.UtcNow;
            _items[index] = entity;
        }
    }
}
