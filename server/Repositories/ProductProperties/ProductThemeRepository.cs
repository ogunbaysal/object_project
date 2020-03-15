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
    public class ProductThemeRepository : BaseRepository, Interface.IRepository<ProductTheme>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductThemeRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductTheme item)
        {
            await _context.ProductThemes.AddAsync(item);
        }

        public async Task<ProductTheme> FindByIdAsync(long id)
        {
            var item = await _context.ProductThemes
                .AsNoTracking()
                .FirstAsync(x => x.ProductThemeId == id);
            return item;
        }

        public async Task<IEnumerable<ProductTheme>> ListAsync(SieveModel query)
        {
            var items = _context.ProductThemes.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductTheme>> ListAsync(System.Linq.Expressions.Expression<Func<ProductTheme, bool>> query)
        {
            var items = _context.ProductThemes.Where(query).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(ProductTheme item)
        {
            _context.ProductThemes.Remove(item);
        }

        public void Update(ProductTheme item)
        {
            _context.ProductThemes.Update(item);
        }
    }
}
