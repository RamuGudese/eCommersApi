using ecomApi.Controllers.DTOs;
using System.Collections.Generic;

namespace ecomApi.Interface
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategoories(); /// get
        CategoryDto CreateCategory(CategoryDto dto);    // post  

        CategoryDto UpdateCategory(int id, CategoryDto dto); // update
        bool  DeleteCategory(int id); // delete
    }
}
