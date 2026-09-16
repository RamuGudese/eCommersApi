using ecomApi.Controllers.DTOs;
using ecomApi.Controllers.Models;
using ecomApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ecomApi.Controllers
{
    [Route("api/CategoryMaster")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        

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
        [HttpPut]
        [Route("UpdateCategory")]

        public IActionResult UpdateCategory(int id, CategoryDto dto)
        {
            var updateData = _categoryService.UpdateCategory(id, dto);
            return StatusCode(200, updateData);

        }

        [HttpDelete]
        [Route("DeleteCategoryById")]
        public IActionResult DropCategory(int id)
        {
            _categoryService.DeleteCategory(id); // void method called directly
            return NoContent(); // or return Ok(new { success = true, message = "Deleted" });
        }


    }
}
