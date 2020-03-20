using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Product;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Products
{
    public class ProductRepository : BaseRepository, Interface.IRepository<Product>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductRepository(ModelContext context, SieveProcessor processor) : base(context) {
            this._sieveProcessor = processor;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(long id)
        {
            var Product = await _context
                .Products
                .Include(x => x.ChildCategory)
                .AsNoTracking()
                .FirstAsync(x => x.ProductId == id);
            return Product;
        }

        public async Task<IEnumerable<Product>> ListAsync(SieveModel query)
        {
            IQueryable<Product> result = _context.Products
               .Include(x => x.ChildCategory)
               .AsNoTracking();
            result = _sieveProcessor.Apply(query, result);
            return await result.ToListAsync();

        }
        public async Task<IEnumerable<Product>> ListAsync(System.Linq.Expressions.Expression<Func<Product, bool>> query)
        {
            var items = _context.Products.Where(query).Include(x => x.ChildCategory).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
