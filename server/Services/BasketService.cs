using server.Helpers;
using server.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IBasketService
    {
        public ICollection<Basket> GetUserBasket(long UserId);
        public void AddItem(long UserId, long ProductPropertId, int Count);
        public void RemoveItem(long UserId, long ProductPropertId, int Count);
        public void Clear(long UserId);
    }
    public class BasketService : IBasketService
    {
        private readonly ModelContext _context;
        public BasketService(ModelContext context)
        {
            _context = context;
        }

        public ICollection<Basket> GetUserBasket(long UserId)
        {
            var list = _context.Baskets.Where(x => x.UserId == UserId && x.Status == BasketStatus.ACTIVE).ToList();
            if (list.Any())
            {
                return list;
            }
            else
            {
                throw new AppException("No User Basket Found");
            }
        }
        public void AddItem(long UserId, long ProductPropertId, int Count)
        {
            if (Count <= 0) throw new AppException("Count cannot be less than zero");
            var isExists = _context.Baskets.First(x => x.UserId == UserId && x.Status == BasketStatus.ACTIVE && x.ProductPropertyId == ProductPropertId);
            if(isExists == null)
            {
                Basket basket = new Basket()
                {
                    UserId = UserId,
                    ProductPropertyId = ProductPropertId,
                    Count = Count,
                    Status = BasketStatus.ACTIVE
                };
                _context.Baskets.Add(basket);
            }
            else
            {
                isExists.Count += Count;
                _context.Baskets.Update(isExists);
            }
            _context.SaveChanges();
        }
        public void RemoveItem(long UserId, long ProductPropertId, int Count)
        {
            if (Count <= 0) throw new AppException("Count cannot be less than zero");
            var isExists = _context.Baskets.First(x => x.UserId == UserId && x.Status == BasketStatus.ACTIVE && x.ProductPropertyId == ProductPropertId);
            if(isExists != null)
            {
                if(isExists.Count - Count <= 0)
                {
                    isExists.Status = BasketStatus.PASSIVE;
                }
                else
                {
                    isExists.Count -= Count;
                }
                _context.Baskets.Update(isExists);
                _context.SaveChanges();
            }
            else
            {
                throw new AppException("No basket found");
            }
        }
        public void Clear(long UserId)
        {
            var list = _context.Baskets.Where(x => x.UserId == UserId && x.Status == BasketStatus.ACTIVE).ToList();
            foreach(var item in list)
            {
                item.Status = BasketStatus.PASSIVE;
                _context.Baskets.Update(item);
            }
            _context.SaveChanges();
        }
    }
}
