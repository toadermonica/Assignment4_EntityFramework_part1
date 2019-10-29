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
        /// <returns>List of Categories and Ok response</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            if(_dataService.CreateCategory(category.Name, category.Description) == null)
            {
                return NotFound(); // this is not required by the unit test but it would be nice to know what to return in this case;
            }

            return Ok(category);
        }


    }
}
