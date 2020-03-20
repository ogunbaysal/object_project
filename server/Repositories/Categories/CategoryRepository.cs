using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Category;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Categories
{
    public class CategoryRepository : BaseRepository, Interface.IRepository<Category>
    {
        private readonly SieveProcessor _sieveProcessor;
        public CategoryRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(Category item)
        {
            await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> FindByIdAsync(long id)
        {
            var item = await _context.Categories
                .AsNoTracking()
                .FirstAsync(x => x.CategoryId == id);
            return item;
        }

        public async Task<IEnumerable<Category>> ListAsync(SieveModel query)
        {
            var items = _context.Categories.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<Category>> ListAsync(System.Linq.Expressions.Expression<Func<Category, bool>> query)
        {
            var items = _context.Categories
                .Where(query)
                .AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(Category item)
        {
            _context.Categories.Remove(item);
            _context.SaveChanges();

        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
            _context.SaveChanges();
        }
    }
}
