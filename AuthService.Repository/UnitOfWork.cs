using System;
using System.Collections.Generic;
using System.Linq;
using AuthService.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repository
{
    public class UnitOfWork<C> : IDisposable, IUnitOfWork<C> where C : DbContext, new()
    {
        private C context;
        
        public Dictionary<Type, object> repositories { get; set; }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (!repositories.Keys.Contains(typeof(T)))
            {
                IRepository<T> repo = new Repository<T>(context);
                repositories.Add(typeof(T), repo);
            }

            return repositories[typeof(T)] as IRepository<T>;
        }
        
        public UnitOfWork(DbContext dbContext)
        {
            context = new C();
            repositories = new Dictionary<Type, object>();
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Commit()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
