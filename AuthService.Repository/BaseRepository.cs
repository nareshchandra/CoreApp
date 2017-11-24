using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AuthService.Entity;

//http://www.infragistics.com/community/blogs/dhananjay_kumar/archive/2016/03/07/how-to-implement-the-repository-pattern-in-asp-net-mvc-application.aspx
//http://www.codeproject.com/Articles/770156/Understanding-Repository-and-Unit-of-Work-Pattern
//http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
namespace AuthService.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public DbContext context { get; set; }

        public Repository(DbContext _context)
        {
            context = _context;
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return context.Set<T>().Where(predicate);
                }
            }
            return context.Set<T>().AsNoTracking();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Edit(T entityExtsing, T entityNew)
        {
            context.Entry<T>(entityExtsing).CurrentValues.SetValues(entityNew);
            context.Entry(entityExtsing).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
        }


        public virtual IQueryable<T> GetAsQueryable()
        {
            return context.Set<T>().AsNoTracking();
        }        
    }   
}
