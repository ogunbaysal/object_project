using server.Helpers;
using server.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Threading.Tasks;
using server.Filter;
using server.Seeds;

namespace server.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(PaginationSearchModel pagination);
        Task<Product> GetById(long id);
        Task AddProduct(Product product);
        Task AddProductProperty(ProductProperty item);
        void Seed();
    }
    public class ProductService : IProductService
    {
        private readonly ModelContext _context;

        public ProductService(ModelContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            var seeder = new ProductSeeder(_context);
            seeder.Seed();
        }
        public IEnumerable<Product> GetAll(PaginationSearchModel pagination)
        {
            var pageSize = pagination.itemCount.HasValue ? pagination.itemCount.Value : 10;
            int pageNumber = pagination.page.HasValue ? pagination.page.Value : 1;
            string sortBy = String.IsNullOrEmpty(pagination.sort) ? "ProductId" : pagination.sort;
            if (!String.IsNullOrEmpty(pagination.searchString))
            {
                var products = _context
                .Products
                .Where(
                    x => 
                    x.Title.Contains(pagination.searchString, StringComparison.OrdinalIgnoreCase) ||
                    x.Description.Contains(pagination.searchString, StringComparison.OrdinalIgnoreCase)
                )
                .OrderByDescending(x => x.GetType().Name == sortBy)
                .ToPagedList(pageNumber, pageSize);
                if (products.Any())
                {
                    return products;
                }
                else
                {
                    throw new AppException("No Product Found");
                }
            }
            else
            {
                var products = _context
                .Products
                .ToPagedList(pageNumber, pageSize);
                if (products.Any())
                {
                    return products;
                }
                else
                {
                    throw new AppException("No Product Found");
                }
            }
            
        }
        public async Task<Product> GetById(long id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null) return Product;
            throw new AppException("Product Not Found");
        }
        public async Task AddProduct(Product product) 
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task AddProductProperty(ProductProperty item)
        {
            _context.ProductProperties.Add(item);
            await _context.SaveChangesAsync();
        }

    }
}
