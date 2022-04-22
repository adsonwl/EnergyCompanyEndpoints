using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnergyEndpoint.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly EnergyEndpointDbContext _context;
        public Repository(EnergyEndpointDbContext context)
        {
            _context = context;
        }
        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public bool Update(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return true;
        }
        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable<T>();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }
    }
}
