using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Order;
using server.Repositories.Interface;
using server.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IOrderService
    {
        Task OrderBasketAsync(Order order, ICollection<Basket> baskets);
        Task<IEnumerable<Order>> GetOrdersAsync(long UserId);
    }
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task OrderBasketAsync(Order order, ICollection<Basket> baskets)
        {
            await _orderRepository.AddAsync(order);
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
                await _orderDetailRepository.AddAsync(detail);
            }
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(long UserId)
        {
            var items = await _orderRepository.ListAsync(x => x.UserId == UserId);
            return items.ToList();
        }
    }
}
