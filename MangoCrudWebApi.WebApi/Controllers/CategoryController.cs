using MangoCrudWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoCrudWebApi.WebApi.Controllers
{
    //Test
    [ApiController]
    [Route("demo/api/[controller]")]
    //[Route("[controller]")] route controller is branch
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _CategoryService;
        public CategoryController(IMongoDbSettings settings)
        {
            this._CategoryService = new CategoryService(settings);
        }
        [HttpGet("get")]
        public ActionResult<List<Category>> Get() => _CategoryService.GetAll();
        //[HttpGet("{id:lenght(24)}")]
        [HttpGet("getbyid/{id:length(24)}")]
        public ActionResult<Category> GetById(string id) => _CategoryService.SelectById(id);

        [HttpGet("getall")]
        public ActionResult<List<Category>> GetAll()
        {
            var AllCategory = _CategoryService.GetAll();
            return AllCategory;
        }


    }
}
