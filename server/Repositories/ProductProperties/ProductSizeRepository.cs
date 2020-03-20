using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.ProductProperty;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.ProductProperties
{
    public class ProductSizeRepository : BaseRepository, Interface.IRepository<ProductSize>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductSizeRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductSize item)
        {
            await _context.ProductSizes.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductSize> FindByIdAsync(long id)
        {
            var item = await _context.ProductSizes
                .AsNoTracking()
                .FirstAsync(x => x.ProductSizeId == id);
            return item;
        }

        public async Task<IEnumerable<ProductSize>> ListAsync(SieveModel query)
        {
            var items = _context.ProductSizes.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductSize>> ListAsync(System.Linq.Expressions.Expression<Func<ProductSize, bool>> query)
        {
            var items = _context.ProductSizes.Where(query).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(ProductSize item)
        {
            _context.ProductSizes.Remove(item);
            _context.SaveChanges();
        }

        public void Update(ProductSize item)
        {
            _context.ProductSizes.Update(item);
            _context.SaveChanges();

        }
    }
}
