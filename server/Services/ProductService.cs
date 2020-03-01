using server.Helpers;
using server.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Collections;

namespace server.Services
{
    public interface IProductService
    {
        IEnumerable<object> GetAll(SieveModel sieveModel);
        Task<Product> GetById(long id);
        Task AddProduct(Product product);
        Task AddProductProperty(ProductProperty item);
        Task<ICollection<object>> GetProductProperties(long ProductId);
    }
    public class ProductService : IProductService
    {
        private readonly ModelContext _context;
        private SieveProcessor _sieveProcessor;

        public ProductService(ModelContext context, SieveProcessor processor)
        {
            _context = context;
            _sieveProcessor = processor;
        }
        public IEnumerable<object> GetAll(SieveModel sieveModel)
        {
            var result = _context.Products
                .Include(x => x.ChildCategory)
                .Select(x =>
                    new
                    {
                        ProductId = x.ProductId,
                        ChildCategory = new
                        {
                            ChildCategoryId = x.ChildCategory.ChildCategoryId,
                            Title = x.ChildCategory.Title,
                            Slug = x.ChildCategory.Slug
                        },
                        Title = x.Title,
                        Description = x.Description,
                        DateCreated = x.DateCreated,
                        DateModified = x.DateModified
                    }
                 )
                .AsNoTracking();
            result = _sieveProcessor.Apply(sieveModel, result);
            
            return result;
        }
        public async Task<ICollection<object>> GetProductProperties(long ProductId)
        {
            var properties = await _context.ProductProperties
                    .Where(x => x.ProductId == ProductId)
                    .Include(x => x.ProductColor)
                    .Include(x => x.ProductHeight)
                    .Include(x => x.ProductSize)
                    .Include(x => x.ProductTheme)
                    .Include(x => x.ProductTrotter)
                    .ToListAsync();
            var items = new List<object>();
            foreach (var property in properties)
            {
                var Color = property.ProductColorId is null ? null : new
                {
                    ColorId = property.ProductColor.ProductColorId,
                    Tag = property.ProductColor.Tag,
                    Url = property.ProductColor.Url
                };
                var Size = property.ProductSizeId is null ? null : new
                {
                    SizeId = property.ProductSize.ProductSizeId,
                    Title = property.ProductSize.Title
                };
                var Height = property.ProductHeightId is null ? null : new
                {
                    HeightId = property.ProductHeight.ProductHeightId,
                    Title = property.ProductHeight.Title
                };
                var Theme = new
                {
                    ThemeId = property.ProductTheme.ProductThemeId,
                    Title = property.ProductTheme.Title,
                    Slug = property.ProductTheme.Slug
                };
                var Trotter = property.ProductTrotterId is null ? null : new
                {
                    TrotterId = property.ProductTrotter.ProductTrotterId,
                    Title = property.ProductTrotter.Title,
                    Slug = property.ProductTrotter.Slug
                };
                items.Add(new
                {
                    Title = property.Title,
                    Description = property.Description,
                    DateCreated = property.DateCreated,
                    DateModified = property.DateModified,
                    Color = Color,
                    Height = Height,
                    Size = Size,
                    Theme = Theme,
                    Trotter = Trotter
                });
            }
            return items.ToArray();
        }
        public async Task<Product> GetById(long id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null) return Product;
            throw new AppException("Product Not Found");
        }
        public async Task AddProduct(Product product) 
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task AddProductProperty(ProductProperty item)
        {
            _context.ProductProperties.Add(item);
            await _context.SaveChangesAsync();
        }

    }
}
