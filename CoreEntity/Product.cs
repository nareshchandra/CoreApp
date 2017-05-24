﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace CoreEntity
{
    public class Product:IEntity
    {
        public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("Price")]
        public int Price { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("ProductCode")]
        public string ProductCode { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
    }
}