using System.Collections.Generic;
using System.Linq;
using ecomApi.Controllers.DTOs;
using ecomApi.Controllers.Models;
using ecomApi.Interface;

namespace ecomApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EcomDbContext _dbContext;

        public CategoryService(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryDto> GetCategoories()
        {
            var categoryData = _dbContext.CategoryModels
                .Select(x => new CategoryDto
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    CategoryLogo = x.CategoryLogo
                })
                .ToList();

            return categoryData;
        }

       public CategoryDto CreateCategory(CategoryDto dto)
        {
            var newCategory = new CategoryModel
            {
                CategoryName = dto.CategoryName,
                CategoryLogo = dto.CategoryLogo
            };
            _dbContext.CategoryModels.Add(newCategory);
            _dbContext.SaveChanges();

            return new CategoryDto
            {
                CategoryId = newCategory.CategoryId,
                CategoryName = newCategory.CategoryName,
                CategoryLogo = newCategory.CategoryLogo
            };
        }









    }
}
