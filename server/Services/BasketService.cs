using server.Helpers;
using server.Models.Order;
using server.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IBasketService
    {
        public Task<IEnumerable<Basket>> GetUserBasketAsync(long UserId);
        public Task AddItemAsync(long UserId, long ProductPropertId, int Count);
        public void RemoveItem(long UserId, long ProductPropertId, int Count);
        public Task ClearAsync(long UserId);
    }
    public class BasketService : IBasketService
    {
        private readonly BasketRepository _basketRepository;
        public BasketService(BasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        public async Task<IEnumerable<Basket>> GetUserBasketAsync(long UserId)
        {
            var list = await _basketRepository.GetUserBasket(UserId); 
            if (list.Any())
            {
                return list;
            }
            else
            {
                throw new AppException("No User Basket Found");
            }
        }
        public async Task AddItemAsync(long UserId, long ProductPropertId, int Count)
        {
            if (Count <= 0) throw new AppException("Count cannot be less than zero");
            var userBasket = _basketRepository.GetUserBasket(UserId);
            var isExists = userBasket.Result.First(x => x.ProductPropertyId == ProductPropertId && x.Status == BasketStatus.ACTIVE);
            if(isExists == null)
            {
                // if the basket item does not exist create new one and add it.
                Basket basket = new Basket()
                {
                    UserId = UserId,
                    ProductPropertyId = ProductPropertId,
                    Count = Count,
                    Status = BasketStatus.ACTIVE
                };
                await _basketRepository.AddAsync(basket);
            }
            else
            {
                // increase the count of item if the basket item exists and update it
                isExists.Count += Count;
                _basketRepository.Update(isExists);
            }
        }
        public void RemoveItem(long UserId, long ProductPropertId, int Count)
        {
            if (Count <= 0) throw new AppException("Count cannot be less than zero");
            var userBasket = _basketRepository.GetUserBasket(UserId);
            var isExists = userBasket.Result.First(x => x.ProductPropertyId == ProductPropertId && x.Status == BasketStatus.ACTIVE);
            if (isExists != null)
            {
                if(isExists.Count - Count <= 0)
                {
                    isExists.Status = BasketStatus.DELETED;
                }
                else
                {
                    isExists.Count -= Count;
                }
                _basketRepository.Update(isExists);
            }
            else
            {
                throw new AppException("No basket found");
            }
        }
        public async Task ClearAsync(long UserId)
        {
            var list = await _basketRepository.ListAsync(x=>x.Status == BasketStatus.ACTIVE && x.UserId == UserId);
            foreach(var item in list)
            {
                item.Status = BasketStatus.DELETED;
                _basketRepository.Update(item);
            }
        }
    }
}
