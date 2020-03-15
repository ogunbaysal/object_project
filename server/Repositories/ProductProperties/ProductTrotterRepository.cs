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
    public class ProductTrotterRepository : BaseRepository, Interface.IRepository<ProductTrotter>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductTrotterRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductTrotter item)
        {
            await _context.ProductTrotters.AddAsync(item);
        }

        public async Task<ProductTrotter> FindByIdAsync(long id)
        {
            var item = await _context.ProductTrotters
                .AsNoTracking()
                .FirstAsync(x => x.ProductTrotterId == id);
            return item;
        }

        public async Task<IEnumerable<ProductTrotter>> ListAsync(SieveModel query)
        {
            var items = _context.ProductTrotters.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductTrotter>> ListAsync(System.Linq.Expressions.Expression<Func<ProductTrotter, bool>> query)
        {
            var items = _context.ProductTrotters.Where(query).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(ProductTrotter item)
        {
            _context.ProductTrotters.Remove(item);
        }

        public void Update(ProductTrotter item)
        {
            _context.ProductTrotters.Update(item);
        }
    }
}
