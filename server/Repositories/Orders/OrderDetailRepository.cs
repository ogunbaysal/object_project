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
    public class OrderDetailRepository : BaseRepository, Interface.IRepository<OrderDetail>
    {
        private readonly SieveProcessor _sieveProcessor;
        public OrderDetailRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(OrderDetail item)
        {
            await _context.OrderDetails.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDetail> FindByIdAsync(long id)
        {
            var item = await _context.OrderDetails
                .Include(x => x.OrderId)
                .AsNoTracking()
                .FirstAsync(x => x.OrderDetailId == id);
            return item;
        }

        public async Task<IEnumerable<OrderDetail>> ListAsync(SieveModel query)
        {
            var items = _context.OrderDetails.Include(x => x.OrderId).AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<OrderDetail>> ListAsync(System.Linq.Expressions.Expression<Func<OrderDetail, bool>> query)
        {
            var items = _context.OrderDetails.Where(query).Include(x => x.OrderId).AsNoTracking();
            return await items.ToListAsync();
        }
        public void Remove(OrderDetail item)
        {
            _context.OrderDetails.Remove(item);
            _context.SaveChanges();

        }

        public void Update(OrderDetail item)
        {
            _context.OrderDetails.Update(item);
            _context.SaveChanges();

        }
    }
}
