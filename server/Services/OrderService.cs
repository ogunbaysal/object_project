using server.Helpers;
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
    }
}
