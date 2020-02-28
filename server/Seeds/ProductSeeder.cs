using server.Helpers;
using server.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Seeds
{
    public class ProductSeeder : Seeder
    {
        private readonly ModelContext _context;
        public ProductSeeder(ModelContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var product1 = new Product()
            {
                ProductId = 1,
                Title = "Logo Printed Sweatshirt",
                Description = "Discover Mavi Printed Sweatshirt from Mavi s Men Collection Mavi Logo Comfort 71 % Cotton 29 % Polyester White Crew Neck"
            };
            _context.Products.Add(product1);
            var productPropert1 = new ProductProperty()
            {
                ProductId = product1.ProductId,
                ProductColor = _context.ProductColors.First(x => x.ProductColorId == 1),
                ProductHeight = _context.ProductHeights.First(x => x.ProductHeightId == 1)
            };
            _context.ProductProperties.Add(productPropert1);
            _context.SaveChanges();
        }
    }
}
