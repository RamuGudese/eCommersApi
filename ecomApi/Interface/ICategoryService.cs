using ecomApi.Controllers.DTOs;
using System.Collections.Generic;

namespace ecomApi.Interface
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategoories();
    }
}
