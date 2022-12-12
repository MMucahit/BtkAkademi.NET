using Repositories.Abstracts;
using System.Linq.Expressions;

namespace Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public readonly RepositoryContext _context;
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
