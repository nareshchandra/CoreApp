using System;
using System.Linq;
using AuthService.Entity;

namespace AuthService.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Edit(T entityExtsing, T entityNew);
        void Delete(T entity);
        T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsQueryable();
    }
}
