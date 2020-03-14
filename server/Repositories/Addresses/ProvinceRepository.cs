using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Address;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Addresses
{
    public class ProvinceRepository : BaseRepository, Interface.IRepository<Province>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProvinceRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(Province item)
        {
            await _context.Provinces.AddAsync(item);
        }

        public async Task<Province> FindByIdAsync(long id)
        {
            var item = await _context.Provinces
                .AsNoTracking()
                .FirstAsync(x => x.ProvinceId == id);
            return item;
        }

        public async Task<IEnumerable<Province>> ListAsync(SieveModel query)
        {
            var items = _context.Provinces.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(Province item)
        {
            _context.Provinces.Remove(item);
        }

        public void Update(Province item)
        {
            _context.Provinces.Update(item);
        }
    }
}
