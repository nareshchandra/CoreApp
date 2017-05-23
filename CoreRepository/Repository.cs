using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using CoreEntity;

namespace CoreRepository
{
    public interface IRepository<T> where T:IEntity
    {
        IEnumerable<T> GetAll();
        T Get();
        bool Add<T>();
        bool Remove<T>();
    }

    public class MongoRepository<T>:IRepository<T> where T:IEntity
    {   
        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _db;
        private string _collectionName;

        public MongoRepository()
        {
            //e.g. for Product entity the name of collection is Products  
            _collectionName = string.Concat(typeof(T).Name, "s");

            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("ProductDB");            
        }

      public IEnumerable<T> GetAll()
      {
         return _db.GetCollection<T>(_collectionName).FindAll();
      }

      public T Get()
      {
         return default(T);
      }

      public bool Add<T>()
      {          
         return true;
      }

      public bool Remove<T>()
      {          
         return true;
      }    
    }
}
