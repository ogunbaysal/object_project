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
    public class SubCategoryRepository : BaseRepository, Interface.IRepository<SubCategory>
    {
        private readonly SieveProcessor _sieveProcessor;
        public SubCategoryRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(SubCategory item)
        {
            await _context.SubCategories.AddAsync(item);
        }

        public async Task<SubCategory> FindByIdAsync(long id)
        {
            var item = await _context.SubCategories
                .Include(x => x.ParentCategoryId)
                .AsNoTracking()
                .FirstAsync(x => x.SubCategoryId == id);
            return item;
        }

        public async Task<IEnumerable<SubCategory>> ListAsync(SieveModel query)
        {
            var items = _context.SubCategories
                .Include(x => x.ParentCategoryId)
                .AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(SubCategory item)
        {
            _context.SubCategories.Remove(item);
        }

        public void Update(SubCategory item)
        {
            _context.SubCategories.Update(item);
        }
    }
}
