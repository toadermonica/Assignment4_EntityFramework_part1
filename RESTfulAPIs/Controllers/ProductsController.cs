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
    public class ProductsController : ControllerBase
    {
        IDataService _dataService;
        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

       



    }
}
