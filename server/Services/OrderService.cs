using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IOrderService
    {
    }
    public class OrderService : IOrderService
    {
        private readonly ModelContext _context;

        public OrderService(ModelContext context)
        {
            _context = context;
        }
        public async Task OrderBasket(Order order, ICollection<Basket> baskets)
        {
            await _context.Orders.AddAsync(order);
            foreach(var item in baskets)
            {
                var detail = new OrderDetail()
                {
                    ProductProperty = item.ProductProperty,
                    Order = order,
                    Piece = item.Count,
                    UnitPrice = item.ProductProperty.Price,
                    TotalPrice = item.Count * item.ProductProperty.Price
                };
                await _context.OrderDetails.AddAsync(detail);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Order>> GetOrders(long UserId)
        {
            var items = await _context.Orders
                .AsNoTracking()
                .AsQueryable()
                .Where(x => x.UserId == UserId)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Select(y => y.ProductProperty))
                .ToListAsync();
            return items;
        }
    }
}
