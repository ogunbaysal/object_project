using Bogus;
using server.Helpers;
using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Seeds
{
    public class ProductPropertSeeder : Seeder
    {
        public readonly ModelContext _context;
        public ProductPropertSeeder(ModelContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            string[] colors = { "Blue", "Green", "Red", "Black", "White" };
            int[] heights = { 28, 30, 32, 34, 36 };
            string[] themes = { "New Items", "Season Sale", "Mavi Logo", "Smart", "Mavi Black", "Black Pro" };
            string[] trotters = { "Skinny", "Slim Leg", "Straight Leg" };
            foreach(var item in colors)
            {
                ProductColor color = new ProductColor()
                {
                    Tag = item,
                    Url = "test.com/image?file=" + item
                };
                _context.ProductColors.Add(color);
            }
            foreach(var item in heights)
            {
                ProductHeight height = new ProductHeight()
                {
                    Title = item.ToString()
                };
                _context.ProductHeights.Add(height);
            }
            for(int i = 24; i < 50; i++)
            {
                ProductSize size = new ProductSize()
                {
                    Title = i.ToString()
                };
                _context.ProductSizes.Add(size);
            }
            foreach(var item in themes)
            {
                ProductTheme theme = new ProductTheme()
                {
                    Title = item,
                    Slug = item
                };
                _context.ProductThemes.Add(theme);
            }
            foreach(var item in trotters)
            {
                ProductTrotter trotter = new ProductTrotter()
                {
                    Title = item,
                    Slug = item
                };
                _context.ProductTrotters.Add(trotter);
            }
            _context.SaveChanges();
            
        }
    }
}
