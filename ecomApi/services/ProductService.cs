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
                ShortName = p.ShortName,
                Price = p.price.HasValue ? (decimal)p.price.Value : null,
                Description = p.description
            }).ToList();

            return products;
        }


        public ProductDtos CreateProduct(ProductDtos dto)
        {
            var newProduct = new productModel
            {
                productName = dto.ProductName,
                ShortName = dto.ShortName,
                price = dto.Price.HasValue ? (float?)dto.Price.Value : null,
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
            updateProduct.ShortName = dto.ShortName;
            updateProduct.price = dto.Price.HasValue ? (float?)dto.Price.Value : null;
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


    