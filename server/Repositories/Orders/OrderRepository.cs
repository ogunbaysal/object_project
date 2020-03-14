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
    public class OrderRepository : BaseRepository, Interface.IRepository<Order>
    {
        private readonly SieveProcessor _sieveProcessor;
        public OrderRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(Order item)
        {
            await _context.Orders.AddAsync(item);
        }

        public async Task<Order> FindByIdAsync(long id)
        {
            var item = await _context.Orders
                .Include(x=>x.UserId)
                .AsNoTracking()
                .FirstAsync(x => x.OrderId == id);
            return item;
        }

        public async Task<IEnumerable<Order>> ListAsync(SieveModel query)
        {
            var items = _context.Orders.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(Order item)
        {
            _context.Orders.Remove(item);
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);
        }
    }
}
