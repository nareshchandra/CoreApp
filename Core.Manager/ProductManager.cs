using System;
using System.Collections.Generic;
using Core.Entity;
using Core.Repository;
using MongoDB.Bson;

namespace Core.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Product> productRepository;

        public ProductManager(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return productRepository.GetAll(null);
        }

        public Product GetAllProducts()
        {
            return productRepository.Get(null);
        }

        public Product GetProduct()
        {
            return productRepository.Get(null);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public void RemoveProduct(ObjectId Id)
        {
            productRepository.Remove(Id);
        }
    }
}
