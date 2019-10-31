using Assignment4;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        readonly IDataService _dataService;
        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string name)
        {
            var products = _dataService.GetProductByName(name);
            if (products.Count == 0)
            {
                return NotFound(products);
            }

            String s = JsonConvert.SerializeObject(products, Formatting.Indented,
    new JsonSerializerSettings()
    {
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    }
        );

            Console.WriteLine("prodsbynam " + s);

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
        public ActionResult<IEnumerable<Product>> GetProductsByCatId(int categoryId)
        {
            var prods = _dataService.GetProductByCategory(categoryId);
            if (prods.Count == 0)
            {
                return NotFound(prods);
            }


            var prodlist = new List<ProductList>();

            foreach (Product p in prods) {

                var prod = new ProductList();
                prod.Name = p.Name;
                prod.categoryName = p.Category.Name;
                prodlist.Add(prod);

            }
            
            
            String s = JsonConvert.SerializeObject(prodlist, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
                    );

            Console.WriteLine("prodsbycat " + s);

            return Ok(prodlist);
        }
    }

    internal class ProductList
    {
        public string Name { get; set; }
        public string categoryName { get; set; }
    }
}

