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
                ProductId = p.productId,
                CategoryId = p.catId,
                ProductName = p.productName,
                ShortName = p.ShortName,
                Price = p.price,
                Description = p.description
            }).ToList();

            return products;
        }


        public ProductDtos CreateProduct(ProductDtos dto)
        {
            if (dto.CategoryId < 1 || !_dbContext.CategoryModels.Any(c => c.CategoryId == dto.CategoryId))
            {
                throw new ArgumentException($"Category with id {dto.CategoryId} was not found.");
            }

            var newProduct = new productModel
            {
                catId = dto.CategoryId,
                productName = dto.ProductName,
                ShortName = dto.ShortName,
                price = dto.Price,
                description = dto.Description
            };
            _dbContext.productModels.Add(newProduct);
            _dbContext.SaveChanges();
            dto.ProductId = newProduct.productId;
            return dto;
        }

        public ProductDtos UpdateProducts(int id, ProductDtos dto)
        {
            var updateProduct = _dbContext.productModels.SingleOrDefault(p => p.productId == id);
            if (updateProduct == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (dto.CategoryId < 1 || !_dbContext.CategoryModels.Any(c => c.CategoryId == dto.CategoryId))
            {
                throw new ArgumentException($"Category with id {dto.CategoryId} was not found.");
            }

            updateProduct.catId = dto.CategoryId;
            updateProduct.productName = dto.ProductName;
            updateProduct.ShortName = dto.ShortName;
            updateProduct.price = dto.Price;
            updateProduct.description = dto.Description;
            _dbContext.SaveChanges();
            dto.ProductId = updateProduct.productId;
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


    