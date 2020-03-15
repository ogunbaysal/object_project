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
        public async Task<IEnumerable<Basket>> GetUserBasket(long userId)
        {
            var list = await _context
                .Baskets
                .AsNoTracking()
                .Where(x => x.UserId == userId && x.Status == BasketStatus.ACTIVE)
                .ToArrayAsync();
            return list;
        }
        public async Task AddAsync(Basket item)
        {
            await _context.Baskets.AddAsync(item);
            await _context.SaveChangesAsync();
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
            var items = _context.Baskets.Where(x=> x.Status == BasketStatus.ACTIVE).Include(x=>x.ProductPropertyId).AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<Basket>> ListAsync(System.Linq.Expressions.Expression<Func<Basket, bool>> query)
        {
            var items = _context.Baskets.Where(query).Include(x => x.ProductPropertyId).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(Basket item)
        {
            _context.Baskets.Remove(item);
            _context.SaveChanges();
        }
        public void Update(Basket item)
        {
            _context.Baskets.Update(item);
            _context.SaveChanges();
        }
    }
}
