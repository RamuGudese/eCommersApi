using ecomApi.Controllers.DTOs;
using ecomApi.Interface;
using ecomApi.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ecomApi.Controllers
{
    [Route("api/ProductMaster")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService IProductService)
        {
            _ProductService = IProductService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<List<ProductDtos>> GetallProducts()
        {
            var proudctsData = _ProductService.GetProducts().ToList();
            return Ok(proudctsData);
        }

        [HttpPost]
        [Route("CreateProducts")]

        public IActionResult CreateProduct(ProductDtos dto)
        {
            var NewProducts = _ProductService.CreateProduct(dto);

            return StatusCode(201, NewProducts);

        }

        [HttpPut]
        [Route("UpdateProduct")]

        public IActionResult UpdateProduct(int id, ProductDtos dto)
        {
            var updateData = _ProductService.UpdateProducts(id, dto);

            return StatusCode(204, updateData);



        }

        [HttpDelete]
        [Route("DeleteProduct")]

        public IActionResult dropProudct(int id, ProductDtos dto)
        {
            var deleteProduct = _ProductService.DeleteProduct(id);

            return StatusCode(204, deleteProduct);

        }


    }
}
