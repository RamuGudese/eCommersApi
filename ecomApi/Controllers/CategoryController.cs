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

        //public ActionResult<List<CategooryModel>> GetAllCategoryService()
        //{
        //    var categoryData = _categoryService.GetAllCategories().ToList();

        //    return Ok(categoryData); }

        [HttpPost]
        [Route("CreateCetagory")] 
        public CategoryDto AddNew(CategoryDto, obj)
        {
            _categoryService.CategoryModel.AddNew(CategoryDto, obj);
            _categoryService.saveChanges();
            return (obj);
        }
    }
}
