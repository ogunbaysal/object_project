using Fop;
using server.Helpers;
using server.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Task<Product> GetById(long id);
    }
    public class ProductService : IProductService
    {
        private readonly ModelContext _context;

        public ProductService(ModelContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.OrderByDescending(x => x.ProductId);
            if(products.Any())
            {
                return products;
            }
            else
            {
                throw new AppException("No Product Found");
            }
        }

        public async Task<Product> GetById(long id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null) return Product;
            throw new AppException("Product Not Found");
        }
    }
}
