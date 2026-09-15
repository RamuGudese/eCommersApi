using ecomApi.Controllers.DTOs;

namespace ecomApi.Interface
{
    public interface IproductService
    {
        List<ProductDtos> GetProducts();
    }
}
