using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Core.Entity;
using Core.Repository;
using Microsoft.AspNetCore.Cors;

namespace CoreWebAPIApp.Controllers
{
   [Route("api/Product")]
    public class ProductAPIController : Controller
    {
        private readonly IRepository<Product> productRepository;
            
        public ProductAPIController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll(null);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var product = productRepository.Get();
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]Product p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Product p)
        {
            var recId = new ObjectId(id);
            var product = objds.GetProduct(recId);
            if (product == null)
            {
                return NotFound();
            }
            
            objds.Update(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
 
            objds.Remove(product.Id);
            return new OkResult();
        }
    }
}
