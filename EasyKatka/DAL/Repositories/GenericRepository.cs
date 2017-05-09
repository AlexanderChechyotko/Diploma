using Domain.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly DbContext _database;

        public GenericRepository(DbContext dbContext)
        {
            _database = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(int id)
        {
            return _database.Set<T>().Find(id);
        }

        public void Create(T item)
        {
            var result = _database.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var data = _database.Set<T>();
            T item = data.Find(id);
            if (item != null)
                data.Remove(item);
        }
    }
}
