using ecomApi.Controllers.DTOs;
using System.Collections.Generic;

namespace ecomApi.Interface
{
    public interface IProductService
    {
        List<ProductDtos> GetProducts();// get all products
        ProductDtos CreateProduct(ProductDtos dto);   // create new product post
        ProductDtos UpdateProducts(int id, ProductDtos dto); // update product put

        bool DeleteProduct(int id); // delete product
    }
}
