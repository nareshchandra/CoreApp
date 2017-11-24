using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<T> :IDisposable where T : BaseEntity
    {
        IReadOnlyList<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T input);
        void Update(T input);
        void Remove(ObjectId Id);
    }
}
