using System.Collections.Generic;
using System.Linq;
using ecomApi.Controllers.DTOs;
using ecomApi.Controllers.Models;
using ecomApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace ecomApi.services
{
    public class ProductService : IProductService
    {
        private readonly EcomDbContext _dbContext;

        public ProductService(EcomDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<ProductDtos> GetProducts() 
        {
            var products = _dbContext.productModels.

            Select(p => new ProductDtos
            {
                ProductName = p.productName,
                ShortName = p.shotName,
                Price = (decimal)p.price,
                Description = p.description
            }).ToList();

            return products;
        }


        public ProductDtos CreateProduct(ProductDtos dto)
        {
            var newProduct = new productModel
            {
                productName = dto.ProductName,
                shotName = dto.ShortName,
                price = (float)dto.Price,
                description = dto.Description
            };
            _dbContext.productModels.Add(newProduct);
            _dbContext.SaveChanges();
            return dto;
        }

        public ProductDtos UpdateProducts(int id, ProductDtos dto)
        {
            var updateProduct = _dbContext.productModels.SingleOrDefault(p => p.productId == id);
            if (updateProduct == null)
            {
                throw new ArgumentException("Product not found");
            }

            updateProduct.productName = dto.ProductName;
            updateProduct.shotName = dto.ShortName;
            updateProduct.price = (float)dto.Price;
            updateProduct.description = dto.Description;
            _dbContext.SaveChanges();
            return dto;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.productModels.SingleOrDefault(p => p.productId == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.productModels.Remove(product);
            _dbContext.SaveChanges();
            return true;    
            
            
        }



    }
}

   }
