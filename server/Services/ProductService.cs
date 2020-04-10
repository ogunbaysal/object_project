using server.Helpers;
using server.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Collections;
using server.Repositories.Products;
using server.Repositories.Interface;

namespace server.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(SieveModel sieveModel);
        Task<Product> GetByIdAsync(long id);
        Task AddProductAsync(Product product);
        Task AddProductPropertyAsync(ProductProperty item);
        Task<IEnumerable<ProductProperty>> GetProductPropertiesAsync(long ProductId);
        Task<IEnumerable<ProductImage>> GetPropertyImageByPropertyIdAsync(long id);
    }
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductProperty> _productPropertyRepository;
        private readonly IRepository<ProductImage> _productImageRepository;

        public ProductService(
            IRepository<Product> productRepository, 
            IRepository<ProductProperty> productPropertyRepository,
            IRepository<ProductImage> productImageRepository
            )
        {
            _productRepository = productRepository;
            _productPropertyRepository = productPropertyRepository;
            _productImageRepository = productImageRepository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync(SieveModel sieveModel)
        {
            var list = await _productRepository.ListAsync(sieveModel);

            var result = list
                .Where(x => x.Status == ProductStatus.ACTIVE);
            return result;
        }
        public async Task<IEnumerable<ProductProperty>> GetProductPropertiesAsync(long ProductId)
        {
            var properties = await _productPropertyRepository.ListAsync(x => x.ProductId == ProductId);
            return properties.ToList();
        }
        public async Task<Product> GetByIdAsync(long id)
        {
            var Product = await _productRepository.FindByIdAsync(id);
            if (Product != null && Product.Status == ProductStatus.ACTIVE) return Product;
            throw new AppException("Product Not Found");
        }
        public async Task AddProductAsync(Product product) 
        {
            await _productRepository.AddAsync(product);
        }
        public async Task AddProductPropertyAsync(ProductProperty item)
        {
            await _productPropertyRepository.AddAsync(item);
        }
        public async Task<IEnumerable<ProductImage>> GetPropertyImageByPropertyIdAsync(long id)
        {
            var image = await _productImageRepository.ListAsync(x=>x.ProductPropertyId == id);
            if (image != null) return image;
            throw new AppException("No Image Found");
        }
    }
}
