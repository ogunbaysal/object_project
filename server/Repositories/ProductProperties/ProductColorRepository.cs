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
    public class ProductColorRepository : BaseRepository, Interface.IRepository<ProductColor>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductColorRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductColor item)
        {
            await _context.ProductColors.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductColor> FindByIdAsync(long id)
        {
            var item = await _context.ProductColors
                .AsNoTracking()
                .FirstAsync(x => x.ProductColorId == id);
            return item;
        }

        public async Task<IEnumerable<ProductColor>> ListAsync(SieveModel query)
        {
            var items = _context.ProductColors.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductColor>> ListAsync(System.Linq.Expressions.Expression<Func<ProductColor, bool>> query)
        {
            var items = _context.ProductColors.Where(query).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(ProductColor item)
        {
            _context.ProductColors.Remove(item);
            _context.SaveChanges();
        }

        public void Update(ProductColor item)
        {
            _context.ProductColors.Update(item);
            _context.SaveChanges();
        }
    }
}
