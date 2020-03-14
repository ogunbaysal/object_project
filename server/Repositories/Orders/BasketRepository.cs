using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Order;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Orders
{
    public class BasketRepository : BaseRepository, Interface.IRepository<Basket>
    {
        private readonly SieveProcessor _sieveProcessor;
        public BasketRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(Basket item)
        {
            await _context.Baskets.AddAsync(item);
        }

        public async Task<Basket> FindByIdAsync(long id)
        {
            var item = await _context.Baskets
                .Include(x=>x.ProductPropertyId)
                .AsNoTracking()
                .FirstAsync(x => x.BasketId == id);
            return item;
        }

        public async Task<IEnumerable<Basket>> ListAsync(SieveModel query)
        {
            var items = _context.Baskets.Include(x=>x.ProductPropertyId).AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(Basket item)
        {
            _context.Baskets.Remove(item);
        }

        public void Update(Basket item)
        {
            _context.Baskets.Update(item);
        }
    }
}
