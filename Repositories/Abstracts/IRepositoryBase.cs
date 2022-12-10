using System.Linq.Expressions;

namespace Repositories.Abstracts
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T GetById(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
