using Microsoft.EntityFrameworkCore;
using server.Models.Category;
using server.Models.Product;
using server.Models.User;
using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models.Address;
using server.Models.Order;

namespace server.Helpers
{
    public class ModelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories {get; set;}
        public DbSet<SubCategory> SubCategories {get; set;}

        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }


        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductTrotter> ProductTrotters { get; set; }
        public DbSet<ProductTheme> ProductThemes{ get; set; }
        public DbSet<ProductHeight> ProductHeights { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public ModelContext(DbContextOptions options) : base(options) 
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
