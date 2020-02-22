using Microsoft.EntityFrameworkCore;
using server.Models.Category;
using server.Models.Product;
using server.Models.User;
using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models.CrossTable;

namespace server.Helpers
{
    public class ModelContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories {get; set;}
        public DbSet<SubCategory> SubCategories {get; set;}


        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductTrotter> ProtectTrotters { get; set; }
        public DbSet<ProductTheme> ProductThemes{ get; set; }
        public DbSet<ProductHeight> ProductHeights { get; set; }


        public DbSet<Product> Products { get; set; }
        public ModelContext(DbContextOptions options) : base(options) { }


        #region Product Cross Tables
        public DbSet<ProductProductSize> ProductProductSizes { get; set; }
        public DbSet<ProductProductColor> ProductProductColors { get; set; }
        public DbSet<ProductProductHeight> ProductProductHeights { get; set; }
        public DbSet<ProductProductTheme> ProductProductThemes { get; set; }
        public DbSet<ProductProductTrotter> ProductProductTrotters { get; set; }
               

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
