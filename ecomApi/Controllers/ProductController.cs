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
        [Route("GetAllProducts")]
        public ActionResult<List<ProductDtos>> GetAllProducts()
        {
            var proudctsData = _ProductService.GetProducts().ToList();
            return Ok(proudctsData);
        }

        [HttpPost]
        [Route("CreateProducts")]

        public IActionResult CreateProduct(ProductDtos dto)
        {
            try
            {
                var NewProducts = _ProductService.CreateProduct(dto);
                return StatusCode(201, NewProducts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("UpdateProduct/{id:int:min(1)}")]
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(
            [FromRoute(Name = "id")] int? routeId,
            [FromQuery(Name = "id")] int? queryId,
            [FromQuery(Name = "productId")] int? productId,
            [FromBody] ProductDtos dto)
        {
            var id = routeId ?? queryId ?? productId;

            if (!id.HasValue)
            {
                return BadRequest("Product ID is required.");
            }

            if (id.Value < 1)
            {
                return BadRequest("Product ID must be greater than zero.");
            }

            try
            {
                _ProductService.UpdateProducts(id.Value, dto);
            }
            catch (ArgumentException ex) when (ex.Message == "Product not found")
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();



        }

        [HttpDelete("DeleteProduct/{id:int:min(1)}")]
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(
            [FromRoute(Name = "id")] int? routeId,
            [FromQuery(Name = "id")] int? queryId,
            [FromQuery(Name = "productId")] int? productId)
        {
            var id = routeId ?? queryId ?? productId;

            if (!id.HasValue || id < 1)
            {
                return BadRequest("Product ID must be greater than zero.");
            }

            var deleted = _ProductService.DeleteProduct(id.Value);

            if (!deleted)
            {
                return NotFound("Product not found");
            }  

            return NoContent();

        }


    }
}
