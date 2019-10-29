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
    //[Route("api/products/name")]
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





    }
}
