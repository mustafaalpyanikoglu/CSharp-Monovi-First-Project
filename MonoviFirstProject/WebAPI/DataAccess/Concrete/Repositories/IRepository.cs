using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
    }
}
