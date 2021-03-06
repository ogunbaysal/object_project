﻿using Microsoft.EntityFrameworkCore;
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
    public class DistrictRepository : BaseRepository, Interface.IRepository<District>
    {
        private readonly SieveProcessor _sieveProcessor;
        public DistrictRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(District item)
        {
            await _context.Districts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<District> FindByIdAsync(long id)
        {
            var item = await _context.Districts
                .Include(x => x.ProvinceId)
                .AsNoTracking()
                .FirstAsync(x => x.DistrictId == id);
            return item;
        }

        public async Task<IEnumerable<District>> ListAsync(SieveModel query)
        {
            var items = _context.Districts.Include(x => x.ProvinceId).AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<District>> ListAsync(System.Linq.Expressions.Expression<Func<District, bool>> query)
        {
            var items = _context.Districts
                .Where(query)
                .Include(x => x.ProvinceId)
                .AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(District item)
        {
            _context.Districts.Remove(item);
            _context.SaveChanges();
        }

        public void Update(District item)
        {
            _context.Districts.Update(item);
            _context.SaveChanges();
        }
    }
}
