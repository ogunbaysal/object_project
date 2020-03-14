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
    public class ProductHeightRepository : BaseRepository, Interface.IRepository<ProductHeight>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductHeightRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductHeight item)
        {
            await _context.ProductHeights.AddAsync(item);
        }

        public async Task<ProductHeight> FindByIdAsync(long id)
        {
            var item = await _context.ProductHeights
                .AsNoTracking()
                .FirstAsync(x => x.ProductHeightId == id);
            return item;
        }

        public async Task<IEnumerable<ProductHeight>> ListAsync(SieveModel query)
        {
            var items = _context.ProductHeights.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(ProductHeight item)
        {
            _context.ProductHeights.Remove(item);
        }

        public void Update(ProductHeight item)
        {
            _context.ProductHeights.Update(item);
        }
    }
}
