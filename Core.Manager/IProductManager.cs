using System.Collections.Generic;
using Core.Entity;
using MongoDB.Bson;

namespace Core.Manager
{
    public interface IProductManager
    {
        Product GetAllProducts();
        Product GetProduct();
        IReadOnlyList<Product> GetProducts();
        void RemoveProduct(ObjectId Id);
        void UpdateProduct(Product product);
    }
}