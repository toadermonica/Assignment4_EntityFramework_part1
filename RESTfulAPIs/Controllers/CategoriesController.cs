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
        readonly IDataService _dataService;
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
            var t = _dataService.CreateCategory(category.Name, category.Description);
            if (t == null)
            {
                return NotFound(); // this is not required by the unit test but it would be nice to know what to return in this case;
            }
            // saw in the framework that it needs a string uri or a uri uri; 
            // since the test does not require it for now, just added a string empty.
            category.Id = t.Id; //small change: needs the new id returned
            return Created(string.Empty, category); 
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteData(int categoryId)
        {
            if (!_dataService.DeleteCategory(categoryId))
                return NotFound();
            return Ok();
        }

        [HttpPut("{categoryId}")]
        public ActionResult PutCategory([FromBody] Category category)
        {
            if (!_dataService.UpdateCategory(category.Id, category.Name, category.Description))
            {
                return NotFound(); 
            }
            return Ok();
        }
    }
}
