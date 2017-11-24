using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Core.Entity;

namespace Core.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //private readonly IMongoClient client;
        //private readonly IMongoDatabase database;
        private IMongoCollection<T> collection;

        public BaseRepository(IMongoDatabase database)
        {
            //_client = new MongoClient("mongodb://localhost:27017");
            //_db = _client.GetDatabase("ProductDB");
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        public IReadOnlyList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return collection.Find(filter).ToList<T>();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return collection.Find(filter).FirstOrDefault<T>();
        }

        public void Add(T input)
        {
            collection.InsertOne(input);
        }

        public void Update(T input)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, input.Id);
            collection.ReplaceOne(filter, input);
        }

        public void Remove(ObjectId Id)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, Id);
            collection.DeleteOne(filter);
        }

        public void Dispose()
        {
            collection = null;
            GC.Collect();
        }
    }
}