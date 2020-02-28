using server.Helpers;
using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IProductPropertyService
    {
        Task<ProductColor> GetColor(long ColorId);
        Task AddColor(ProductColor color);
        Task RemoveColor(long ColorId);
        Task UpdateColor(long Id, ProductColor item);

        Task<ProductHeight> GetHeight(long Id);
        Task AddHeight(ProductHeight item);
        Task RemoveHeight(long Id);
        Task UpdateHeight(long Id, ProductHeight item);

        Task<ProductSize> GetSize(long Id);
        Task AddSize(ProductSize item);
        Task RemoveSize(long Id);
        Task UpdateSize(long Id, ProductSize item);

        Task<ProductTheme> GetTheme(long Id);
        Task AddTheme(ProductTheme item);
        Task RemoveTheme(long Id);
        Task UpdateTheme(long Id, ProductTheme item);

        Task<ProductTrotter> GetTrotter(long Id);
        Task AddTrotter(ProductTrotter item);
        Task RemoveTrotter(long Id);
        Task UpdateTrotter(long Id, ProductTrotter item);
    }
    public class ProductPropertyService : IProductPropertyService
    {
        private readonly ModelContext _context;

        public ProductPropertyService(ModelContext context)
        {
            _context = context;
        }
        #region Color Services
        public async Task AddColor(ProductColor color)
        {
            _context.ProductColors.Add(color);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveColor(long ColorId)
        {
            var item = _context.ProductColors.First(x => x.ProductColorId == ColorId && x.Status != PropertyStatus.DELETED);
            if(item != null)
            {
                item.Status = PropertyStatus.DELETED;
                _context.ProductColors.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AppException("Color is not found");
            }
        }
        public async Task<ProductColor> GetColor(long ColorId)
        {
            var item = _context.ProductColors.First(x => x.ProductColorId == ColorId && x.Status == PropertyStatus.ACTIVE);
            if(item != null)
            {
                return item;
            }
            else
            {
                throw new AppException("Color is not found");
            }
        }
        public async Task UpdateColor(long Id, ProductColor item)
        {
            var obj = _context.ProductColors.First(x => x.ProductColorId == Id);
            if(obj != null)
            {
                obj.Url = item.Url != null ? item.Url : obj.Url;
                obj.Tag = item.Tag != null ? item.Tag : obj.Tag;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _context.ProductColors.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Color is not found");
            }
        }
        #endregion
        #region Height Services
        public async Task AddHeight(ProductHeight item)
        {
            _context.ProductHeights.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveHeight(long Id)
        {
            var item = _context.ProductHeights.First(x => x.ProductHeightId == Id && x.Status != PropertyStatus.DELETED);
            if (item != null)
            {
                item.Status = PropertyStatus.DELETED;
                _context.ProductHeights.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AppException("Height is not found");
            }
        }
        public async Task<ProductHeight> GetHeight(long Id)
        {
            var item = _context.ProductHeights.First(x => x.ProductHeightId == Id && x.Status == PropertyStatus.ACTIVE);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new AppException("Height is not found");
            }
        }
        public async Task UpdateHeight(long Id, ProductHeight item)
        {
            var obj = _context.ProductHeights.First(x => x.ProductHeightId == Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _context.ProductHeights.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Height is not found");
            }
        }

        #endregion
        #region Size Services
        public async Task AddSize(ProductSize item)
        {
            _context.ProductSizes.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveSize(long Id)
        {
            var item = _context.ProductSizes.First(x => x.ProductSizeId == Id && x.Status != PropertyStatus.DELETED);
            if (item != null)
            {
                item.Status = PropertyStatus.DELETED;
                _context.ProductSizes.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AppException("Size is not found");
            }
        }
        public async Task<ProductSize> GetSize(long Id)
        {
            var item = _context.ProductSizes.First(x => x.ProductSizeId == Id && x.Status == PropertyStatus.ACTIVE);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new AppException("Size is not found");
            }
        }
        public async Task UpdateSize(long Id, ProductSize item)
        {
            var obj = _context.ProductSizes.First(x => x.ProductSizeId == Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _context.ProductSizes.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Size is not found");
            }
        }
        #endregion
        #region Theme Services
        public async Task AddTheme(ProductTheme item)
        {
            _context.ProductThemes.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveTheme(long Id)
        {
            var item = _context.ProductThemes.First(x => x.ProductThemeId == Id && x.Status != PropertyStatus.DELETED);
            if (item != null)
            {
                item.Status = PropertyStatus.DELETED;
                _context.ProductThemes.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AppException("Theme is not found");
            }
        }
        public async Task<ProductTheme> GetTheme(long Id)
        {
            var item = _context.ProductThemes.First(x => x.ProductThemeId == Id && x.Status == PropertyStatus.ACTIVE);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new AppException("Theme is not found");
            }
        }
        public async Task UpdateTheme(long Id, ProductTheme item)
        {
            var obj = _context.ProductThemes.First(x => x.ProductThemeId == Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _context.ProductThemes.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Theme is not found");
            }
        }
        #endregion
        #region Trotter Services
        public async Task AddTrotter(ProductTrotter item)
        {
            _context.ProductTrotters.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveTrotter(long Id)
        {
            var item = _context.ProductTrotters.First(x => x.ProductTrotterId == Id && x.Status != PropertyStatus.DELETED);
            if (item != null)
            {
                item.Status = PropertyStatus.DELETED;
                _context.ProductTrotters.Update(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AppException("Trotter is not found");
            }
        }
        public async Task<ProductTrotter> GetTrotter(long Id)
        {
            var item = _context.ProductTrotters.First(x => x.ProductTrotterId == Id && x.Status == PropertyStatus.ACTIVE);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new AppException("Trotter is not found");
            }
        }
        public async Task UpdateTrotter(long Id, ProductTrotter item)
        {
            var obj = _context.ProductTrotters.First(x => x.ProductTrotterId == Id);
            if (obj != null)
            {
                obj.Title = item.Title != null ? item.Title : obj.Title;
                obj.Status = item.Status != null ? item.Status : obj.Status;
                obj.DateModified = DateTime.UtcNow;
                _context.ProductTrotters.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Trotter is not found");
            }
        }
        #endregion

    }
}
