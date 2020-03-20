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
    public class ChildCategoryRepository : BaseRepository, Interface.IRepository<ChildCategory>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ChildCategoryRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ChildCategory item)
        {
            await _context.ChildCategories.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ChildCategory> FindByIdAsync(long id)
        {
            var item = await _context.ChildCategories
                .AsNoTracking()
                .FirstAsync(x => x.ChildCategoryId == id);
            return item;
        }

        public async Task<IEnumerable<ChildCategory>> ListAsync(SieveModel query)
        {
            var items = _context.ChildCategories
                .AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ChildCategory>> ListAsync(System.Linq.Expressions.Expression<Func<ChildCategory, bool>> query)
        {
            var items = _context.ChildCategories
                .Where(query)
                .AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(ChildCategory item)
        {
            _context.ChildCategories.Remove(item);
            _context.SaveChanges();
        }

        public void Update(ChildCategory item)
        {
            _context.ChildCategories.Update(item);
            _context.SaveChanges();
        }
    }
}
