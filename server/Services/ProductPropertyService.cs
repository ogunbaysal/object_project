using server.Helpers;
using server.Models.ProductProperty;
using server.Repositories.ProductProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IProductPropertyService
    {
        Task<ProductColor> GetColorAsync(long ColorId);
        Task AddColorAsync(ProductColor color);
        Task RemoveColorAsync(long ColorId);
        Task UpdateColorAsync(long Id, ProductColor item);

        Task<ProductHeight> GetHeightAsync(long Id);
        Task AddHeightAsync(ProductHeight item);
        Task RemoveHeightAsync(long Id);
        Task UpdateHeightAsync(long Id, ProductHeight item);

        Task<ProductSize> GetSizeAsync(long Id);
        Task AddSizeAsync(ProductSize item);
        Task RemoveSizeAsync(long Id);
        Task UpdateSizeAsync(long Id, ProductSize item);

        Task<ProductTheme> GetThemeAsync(long Id);
        Task AddThemeAsync(ProductTheme item);
        Task RemoveThemeAsync(long Id);
        Task UpdateThemeAsync(long Id, ProductTheme item);

        Task<ProductTrotter> GetTrotterAsync(long Id);
        Task AddTrotterAsync(ProductTrotter item);
        Task RemoveTrotterAsync(long Id);
        Task UpdateTrotterAsync(long Id, ProductTrotter item);
    }
    public class ProductPropertyService : IProductPropertyService
    {
        private readonly ProductColorRepository _productColorRepository;
        private readonly ProductHeightRepository _productHeightRepository;
        private readonly ProductSizeRepository _productSizeRepository;
        private readonly ProductThemeRepository _productThemeRepository;
        private readonly ProductTrotterRepository _productTrotterRepository;

        public ProductPropertyService(
            ProductColorRepository productColorRepository,
            ProductHeightRepository productHeightRepository,
            ProductSizeRepository productSizeRepository,
            ProductThemeRepository productThemeRepository,
            ProductTrotterRepository productTrotterRepository
            )
        {
            _productColorRepository = productColorRepository;
            _productHeightRepository = productHeightRepository;
            _productSizeRepository = productSizeRepository;
            _productThemeRepository = productThemeRepository;
            _productTrotterRepository = productTrotterRepository;
        }
        #region Color Services
        public async Task AddColorAsync(ProductColor color)
        {
            await _productColorRepository.AddAsync(color);
        }
        public async Task RemoveColorAsync(long ColorId)
        {
            var item = await _productColorRepository.FindByIdAsync(ColorId);
            if(item != null && item.Status != PropertyStatus.DELETED)
            {
                item.Status = PropertyStatus.DELETED;
                _productColorRepository.Update(item);
            }
            else
            {
                throw new AppException("Color is not found");
            }
        }
        public async Task<ProductColor> GetColorAsync(long ColorId)
        {
            var item = (await _productColorRepository.FindByIdAsync(ColorId));
            if(item != null && item.Status == PropertyStatus.ACTIVE)
            {
                return item;
            }
            else
            {
                throw new AppException("Color is not found");
            }
        }
        public async Task UpdateColorAsync(long Id, ProductColor item)
        {
            var obj = await _productColorRepository.FindByIdAsync(Id);
            if(obj != null)
            {
                obj.Url = item.Url != null ? item.Url : obj.Url;
                obj.Tag = item.Tag != null ? item.Tag : obj.Tag;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _productColorRepository.Update(obj);
            }
            else
            {
                throw new Exception("Color is not found");
            }
        }
        #endregion
        #region Height Services
        public async Task AddHeightAsync(ProductHeight item)
        {
            await _productHeightRepository.AddAsync(item);
        }
        public async Task RemoveHeightAsync(long Id)
        {
            var item = await _productHeightRepository.FindByIdAsync(Id);
            if (item != null && item.Status != PropertyStatus.DELETED)
            {
                item.Status = PropertyStatus.DELETED;
                _productHeightRepository.Update(item);
            }
            else
            {
                throw new AppException("Height is not found");
            }
        }
        public async Task<ProductHeight> GetHeightAsync(long Id)
        {
            var item = await _productHeightRepository.FindByIdAsync(Id);
            if (item != null && item.Status == PropertyStatus.ACTIVE)
            {
                return item;
            }
            else
            {
                throw new AppException("Height is not found");
            }
        }
        public async Task UpdateHeightAsync(long Id, ProductHeight item)
        {
            var obj = await _productHeightRepository.FindByIdAsync(Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _productHeightRepository.Update(obj);
            }
            else
            {
                throw new Exception("Height is not found");
            }
        }

        #endregion
        #region Size Services
        public async Task AddSizeAsync(ProductSize item)
        {
            await _productSizeRepository.AddAsync(item);
        }
        public async Task RemoveSizeAsync(long Id)
        {
            var item = await _productSizeRepository.FindByIdAsync(Id);
            if (item != null && item.Status != PropertyStatus.DELETED)
            {
                item.Status = PropertyStatus.DELETED;
                _productSizeRepository.Update(item);
            }
            else
            {
                throw new AppException("Size is not found");
            }
        }
        public async Task<ProductSize> GetSizeAsync(long Id)
        {
            var item = await _productSizeRepository.FindByIdAsync(Id);
            if (item != null && item.Status == PropertyStatus.ACTIVE)
            {
                return item;
            }
            else
            {
                throw new AppException("Size is not found");
            }
        }
        public async Task UpdateSizeAsync(long Id, ProductSize item)
        {
            var obj = await _productSizeRepository.FindByIdAsync(Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _productSizeRepository.Update(obj);
            }
            else
            {
                throw new Exception("Size is not found");
            }
        }
        #endregion
        #region Theme Services
        public async Task AddThemeAsync(ProductTheme item)
        {
            await _productThemeRepository.AddAsync(item);
        }
        public async Task RemoveThemeAsync(long Id)
        {
            var item = await _productThemeRepository.FindByIdAsync(Id);
            if (item != null && item.Status != PropertyStatus.DELETED)
            {
                item.Status = PropertyStatus.DELETED;
                _productThemeRepository.Update(item);
            }
            else
            {
                throw new AppException("Theme is not found");
            }
        }
        public async Task<ProductTheme> GetThemeAsync(long Id)
        {
            var item = await _productThemeRepository.FindByIdAsync(Id);
            if (item != null && item.Status == PropertyStatus.ACTIVE)
            {
                return item;
            }
            else
            {
                throw new AppException("Theme is not found");
            }
        }
        public async Task UpdateThemeAsync(long Id, ProductTheme item)
        {
            var obj = await _productThemeRepository.FindByIdAsync(Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _productThemeRepository.Update(obj);
            }
            else
            {
                throw new Exception("Theme is not found");
            }
        }
        #endregion
        #region Trotter Services
        public async Task AddTrotterAsync(ProductTrotter item)
        {
            await _productTrotterRepository.AddAsync(item);
        }
        public async Task RemoveTrotterAsync(long Id)
        {
            var item = await _productTrotterRepository.FindByIdAsync(Id);
            if (item != null && item.Status != PropertyStatus.DELETED)
            {
                item.Status = PropertyStatus.DELETED;
                _productTrotterRepository.Update(item);
            }
            else
            {
                throw new AppException("Trotter is not found");
            }
        }
        public async Task<ProductTrotter> GetTrotterAsync(long Id)
        {
            var item = await _productTrotterRepository.FindByIdAsync(Id);
            if (item != null && item.Status == PropertyStatus.ACTIVE)
            {
                return item;
            }
            else
            {
                throw new AppException("Trotter is not found");
            }
        }
        public async Task UpdateTrotterAsync(long Id, ProductTrotter item)
        {
            var obj = await _productTrotterRepository.FindByIdAsync(Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _productTrotterRepository.Update(obj);
            }
            else
            {
                throw new Exception("Trotter is not found");
            }
        }
        #endregion

    }
}
