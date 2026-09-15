using ecomApi.Controllers.DTOs;
using ecomApi.Controllers.Models;
using ecomApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ecomApi.Controllers
{
    [Route("api/CategoryMaster")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        //private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategory")]
        public ActionResult<List<CategoryDto>> GetAllCategoryService()
        {
            var categoryData = _categoryService.GetCategoories().ToList();
            //Console.WriteLine(categoryData);
            return Ok(categoryData);
        }


        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory(CategoryDto dto)
        {
            var categoryData = _categoryService.CreateCategory(dto);

            return StatusCode(201, categoryData);

        }


    }
}
