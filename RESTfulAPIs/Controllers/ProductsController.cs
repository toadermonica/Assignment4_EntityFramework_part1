using Assignment4;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPIs.Controllers
{
    [ApiController]
    [Route("api/products")]

    public class ProductsController : ControllerBase
    {
        IDataService _dataService;
        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string name)
        {
            var products = _dataService.GetProductByName(name);
            if(products.Count == 0)
            {
                return NotFound(products);
            }
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var product = _dataService.GetProduct(productId);
            if (product == null)
            {
                return NotFound(product);
            }
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<Product>> GetProductsByCatId(int categoryId)
        {
            var prods = _dataService.GetProductByCategory(categoryId);
            if (prods.Count==0)
            {
                    return NotFound(prods);
            }
            Console.WriteLine("blaprods " + prods.Count);
            return Ok(prods);
        }
    }
}

