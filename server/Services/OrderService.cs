using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Order;
using server.Repositories.Orders;
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
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailRepository _orderDetailRepository;
        public OrderService(OrderRepository orderRepository, OrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task OrderBasket(Order order, ICollection<Basket> baskets)
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
        public async Task<ICollection<Order>> GetOrders(long UserId)
        {
            var items = await _orderRepository.ListAsync(x => x.UserId == UserId);
            return items.ToList();
        }
    }
}
