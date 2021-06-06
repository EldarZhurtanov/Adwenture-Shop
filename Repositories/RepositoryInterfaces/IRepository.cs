using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Create(T entity);
        void Delete(T model);
        T Update(T entity);
        IQueryable<T> GetList();
        IQueryable<T> GetList(Expression<Func<T, bool>> predicate);
    }
}
