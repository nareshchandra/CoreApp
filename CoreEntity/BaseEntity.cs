using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entity
{
  public abstract class BaseEntity
  {
        public ObjectId Id { get; set; }
        public BsonDateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public BsonDateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}