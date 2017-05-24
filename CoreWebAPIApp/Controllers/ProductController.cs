using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using CoreEntity;
using CoreRepository;
using Microsoft.AspNetCore.Cors;

namespace CoreWebAPIApp.Controllers
{
   [Route("api/Product")]
    public class ProductAPIController : Controller
    {
        DataAccess objds;
 
        public ProductAPIController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            MongoRepository<Product> rep = new MongoRepository<Product>();
            return rep.GetAll();//objds.GetProducts();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
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
