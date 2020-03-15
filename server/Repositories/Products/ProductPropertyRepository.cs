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
    public class ProductPropertyRepository : BaseRepository, Interface.IRepository<ProductProperty>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductPropertyRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductProperty item)
        {
            await _context.ProductProperties.AddAsync(item);
        }

        public async Task<ProductProperty> FindByIdAsync(long id)
        {
            var item = await _context
                .ProductProperties
                .Include(x => x.ProductSizeId)
                .Include(x => x.ProductThemeId)
                .Include(x => x.ProductTrotterId)
                .Include(x => x.ProductId)
                .Include(x => x.ProductHeightId)
                .Include(x => x.ProductColorId)
                .AsNoTracking()
                .FirstAsync(x => x.ProductPropertId == id);
            return item;
        }

        public async Task<IEnumerable<ProductProperty>> ListAsync(SieveModel query)
        {
            IQueryable<ProductProperty> result = _context
                .ProductProperties
                .Include(x => x.ProductSizeId)
                .Include(x => x.ProductThemeId)
                .Include(x => x.ProductTrotterId)
                .Include(x => x.ProductId)
                .Include(x => x.ProductHeightId)
                .Include(x => x.ProductColorId)
                .AsNoTracking();
            result = _sieveProcessor.Apply(query, result);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductProperty>> ListAsync(System.Linq.Expressions.Expression<Func<ProductProperty, bool>> query)
        {
            var items = _context.ProductProperties
                .Where(query)
                .Include(x => x.ProductSizeId)
                .Include(x => x.ProductThemeId)
                .Include(x => x.ProductTrotterId)
                .Include(x => x.ProductId)
                .Include(x => x.ProductHeightId)
                .Include(x => x.ProductColorId)
                .AsNoTracking();
            return await items.ToListAsync();
        }

        public void Remove(ProductProperty product)
        {
            _context.ProductProperties.Remove(product);
        }

        public void Update(ProductProperty product)
        {
            _context.ProductProperties.Update(product);
        }
    }
}
