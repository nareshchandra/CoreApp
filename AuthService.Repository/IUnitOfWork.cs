using AuthService.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repository
{
    public interface IUnitOfWork<C> where C : DbContext
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        void Dispose();
        void Save();
        void Commit();
    }
}
