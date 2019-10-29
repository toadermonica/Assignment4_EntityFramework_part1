using Assignment4;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPIs.Controllers
{

    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        IDataService _dataService;
        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }


        /// <summary>
        /// GET method for /api/categories resource
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }


    }
}
