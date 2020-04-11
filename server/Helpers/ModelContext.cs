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
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ChildCategory> ChildCategories { get; set; }
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
            modelBuilder.Entity<Province>().HasData(
                new Province() { ProvinceId = 77, Title = "Yalova"},
                new Province() { ProvinceId = 48, Title = "Muğla"},
                new Province() { ProvinceId = 34, Title = "İstanbul"},
                new Province() { ProvinceId = 9, Title = "Ankara"},
                new Province() { ProvinceId = 35, Title = "İzmir"}
                );
            modelBuilder.Entity<District>().HasData(
                new District() { DistrictId = 1, Title = "Merkez", ProvinceId = 77 },
                new District() { DistrictId = 2, Title = "Termal", ProvinceId = 77 },
                new District() { DistrictId = 3, Title = "Çınarcık", ProvinceId = 77 },
                new District() { DistrictId = 4, Title = "Pendik", ProvinceId = 34 },
                new District() { DistrictId = 5, Title = "Kartal", ProvinceId = 34 }

                );
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, Username = "Admin", Password = BCrypt.Net.BCrypt.HashPassword("demo1234"),  Email = "info@ogun.me", Firstname = "Ogün", Lastname = "Baysal", Role = "Admin"},
                new User() { UserId = 2, Username = "ozgurdurak", Password = BCrypt.Net.BCrypt.HashPassword("demo1234"), Email = "ozgur.durak@yandex.com", Firstname = "Özgür", Lastname = "Durak", Role = "User"}
                );
            modelBuilder.Entity<ProductColor>().HasData(
                new ProductColor() { ProductColorId = 1 , Tag = "Blue", Status = PropertyStatus.ACTIVE, Url = "site.com/blue" },
                new ProductColor() { ProductColorId = 2 , Tag = "Red", Status = PropertyStatus.ACTIVE, Url = "site.com/red" },
                new ProductColor() { ProductColorId = 3 , Tag = "Green", Status = PropertyStatus.ACTIVE, Url = "site.com/green" },
                new ProductColor() { ProductColorId = 4 , Tag = "Black", Status = PropertyStatus.ACTIVE, Url = "site.com/black" },
                new ProductColor() { ProductColorId = 5 , Tag = "White", Status = PropertyStatus.ACTIVE, Url = "site.com/white" },
                new ProductColor() { ProductColorId = 6 , Tag = "Purple", Status = PropertyStatus.ACTIVE, Url = "site.com/purple" },
                new ProductColor() { ProductColorId = 7 , Tag = "Navy", Status = PropertyStatus.ACTIVE, Url = "site.com/navy" }
                );
            modelBuilder.Entity<ProductHeight>().HasData(
                new ProductHeight() { ProductHeightId = 28 , Title = "28"},
                new ProductHeight() { ProductHeightId = 30 , Title = "30"},
                new ProductHeight() { ProductHeightId = 32 , Title = "32"},
                new ProductHeight() { ProductHeightId = 34 , Title = "34"},
                new ProductHeight() { ProductHeightId = 36 , Title = "36"}
                );
            modelBuilder.Entity<ProductSize>().HasData(
                new ProductSize() { ProductSizeId = 1 ,  Title = "XXS" },
                new ProductSize() { ProductSizeId = 2 , Title = "XS" },
                new ProductSize() { ProductSizeId = 3, Title = "S" },
                new ProductSize() { ProductSizeId = 4, Title = "M" },
                new ProductSize() { ProductSizeId = 5, Title = "L" },
                new ProductSize() { ProductSizeId = 6, Title = "XL" },
                new ProductSize() { ProductSizeId = 7, Title = "XXL" },
                new ProductSize() { ProductSizeId = 8, Title = "XXXL" },
                new ProductSize() { ProductSizeId = 9, Title = "24" },
                new ProductSize() { ProductSizeId = 10, Title = "26" },
                new ProductSize() { ProductSizeId = 11, Title = "28" },
                new ProductSize() { ProductSizeId = 12, Title = "30" },
                new ProductSize() { ProductSizeId = 13, Title = "32" },
                new ProductSize() { ProductSizeId = 14, Title = "34" },
                new ProductSize() { ProductSizeId = 15, Title = "36" }
                );
            modelBuilder.Entity<ProductTheme>().HasData(
                new ProductTheme() { ProductThemeId= 1 , Title = "New Items", Slug = "new-items"},
                new ProductTheme() { ProductThemeId = 2, Title = "Season Sale", Slug = "season-sale"},
                new ProductTheme() { ProductThemeId = 3, Title = "Mavi Logo", Slug = "mavi-logo"},
                new ProductTheme() { ProductThemeId = 4, Title = "Smart", Slug = "smart"},
                new ProductTheme() { ProductThemeId = 5, Title = "Mavi Black", Slug = "mavi-black"}
                );
            modelBuilder.Entity<ProductTrotter>().HasData(
                new ProductTrotter() { ProductTrotterId = 1, Title = "Long Sleeve", Slug = "long-sleeve" },
                new ProductTrotter() { ProductTrotterId = 2, Title = "Short Sleeve", Slug = "short-sleeve" },
                new ProductTrotter() { ProductTrotterId = 3, Title = "Slim Leg", Slug = "slim-leg" }

                );
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Title = "Women", Slug = "woman"},
                new Category() { CategoryId = 2, Title = "Men", Slug = "men"},
                new Category() { CategoryId = 3, Title = "Child", Slug = "child"},
                new Category() { CategoryId = 4, Title = "Outlet", Slug = "outlet"}
                );
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { SubCategoryId = 1, ParentCategoryId = 2, Title = "Clothes", Slug="clothes" },
                new SubCategory() { SubCategoryId = 2, ParentCategoryId = 2, Title = "Accessories", Slug="accessories" }
                );
            modelBuilder.Entity<ChildCategory>().HasData(
                new ChildCategory() { ChildCategoryId = 1, SubCategoryId = 1, Title = "Denim", Slug = "denim" },
                new ChildCategory() { ChildCategoryId = 2, SubCategoryId = 1, Title = "Shirts", Slug = "shirts" },
                new ChildCategory() { ChildCategoryId = 3, SubCategoryId = 1, Title = "T-Shirts", Slug = "t-shirts" },
                new ChildCategory() { ChildCategoryId = 4, SubCategoryId = 1, Title = "Basics", Slug = "basics" },
                new ChildCategory() { ChildCategoryId = 5, SubCategoryId = 1, Title = "Sweatshirts", Slug = "sweatshirts" },
                new ChildCategory() { ChildCategoryId = 6, SubCategoryId = 1, Title = "Coat - Jacket", Slug = "coat-jacket" },
                new ChildCategory() { ChildCategoryId = 7, SubCategoryId = 1, Title = "Pants", Slug = "pants" },
                new ChildCategory() { ChildCategoryId = 8, SubCategoryId = 1, Title = "Knitwear-Sweaters", Slug = "knitwear-sweaters" },
                new ChildCategory() { ChildCategoryId = 9, SubCategoryId = 2, Title = "Bags-Wallets", Slug = "bags-wallets" },
                new ChildCategory() { ChildCategoryId = 10, SubCategoryId = 2, Title = "Parfume", Slug = "parfume" },
                new ChildCategory() { ChildCategoryId = 11, SubCategoryId = 2, Title = "Belt", Slug = "belt" },
                new ChildCategory() { ChildCategoryId = 12, SubCategoryId = 2, Title = "Scarf-Beret", Slug = "scarf-beret" },
                new ChildCategory() { ChildCategoryId = 13, SubCategoryId = 2, Title = "Hats", Slug = "hats" },
                new ChildCategory() { ChildCategoryId = 14, SubCategoryId = 2, Title = "Boxer", Slug = "boxer" },
                new ChildCategory() { ChildCategoryId = 15, SubCategoryId = 2, Title = "Socks", Slug = "socks" },
                new ChildCategory() { ChildCategoryId = 16, SubCategoryId = 2, Title = "Boxer", Slug = "boxer" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ChildCategoryId = 1, Title = "JAKE", Description = "Normal Bel, Skinny", DateCreated = new DateTime(2020, 4, 14), DateModified = new DateTime(2020, 4, 14) },
                new Product() { ProductId = 2, ChildCategoryId = 2 , Title = "James Black Pro Gölge Mavi Jean Pantolon", Description = "", DateCreated = new DateTime(2020, 4, 14), DateModified = new DateTime(2020, 4, 14) }
                );
            modelBuilder.Entity<ProductProperty>()
                .HasData(
                new ProductProperty() { ProductPropertyId = 1, ProductId = 1, ProductThemeId = 1 ,ProductColorId = 7, ProductHeightId = 32, Price = 269.99, Title = "Jake Vintage Ink Mavi Jet Black Jean Pants", Description = "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection" },
                new ProductProperty() { ProductPropertyId = 11, ProductId = 1, ProductThemeId = 1 ,ProductColorId = 7, ProductHeightId = 34,  Price = 269.99, Title = "Jake Vintage Ink Mavi Jet Black Jean Pants", Description = "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection" },
                new ProductProperty() { ProductPropertyId = 12, ProductId = 1, ProductThemeId = 1, ProductColorId = 5, ProductHeightId = 32, Price = 169.99, Title = "Jake Vintage Ink Mavi Jet Black Jean Pants", Description = "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection" },
                new ProductProperty() { ProductPropertyId = 13, ProductId = 1, ProductThemeId = 1, ProductColorId = 5, ProductHeightId = 34, Price = 169.99, Title = "Jake Vintage Ink Mavi Jet Black Jean Pants", Description = "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection" },
                new ProductProperty() { ProductPropertyId = 2, ProductId = 1, ProductThemeId = 1, ProductColorId = 3, ProductHeightId = 32, ProductSizeId = 2, Price = 269.99, Title = "Jake Black Berlin Jean Pants", Description = "Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection\nNew Items\nRegular Rise\nSkinny\nSlim Leg\n98% Cotton 2% Elastan\nBlack" },
                new ProductProperty() { ProductPropertyId = 3, ProductId = 1, ProductThemeId = 1, ProductColorId = 4, ProductHeightId = 32, ProductSizeId = 2, Price = 269.99, Title = "Jake Black Berlin Jean Pants", Description = "Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection\nNew Items\nRegular Rise\nSkinny\nSlim Leg\n98% Cotton 2% Elastan\nBlack" },
                new ProductProperty() { ProductPropertyId = 4, ProductId = 2, ProductThemeId = 2, ProductColorId = 2, ProductHeightId = 32, ProductSizeId = 1, Price = 269.99, ProductTrotterId = 1, Title = "Jake Black Berlin Jean Pants", Description = "Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection\nNew Items\nRegular Rise\nSkinny\nSlim Leg\n98% Cotton 2% Elastan\nBlack" },
                new ProductProperty() { ProductPropertyId = 5, ProductId = 2, ProductThemeId = 2, ProductColorId = 2, ProductHeightId = 32, ProductSizeId = 1, Price = 269.99, ProductTrotterId = 2, Title = "Jake Black Berlin Jean Pants", Description = "Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection\nNew Items\nRegular Rise\nSkinny\nSlim Leg\n98% Cotton 2% Elastan\nBlack" },
                new ProductProperty() { ProductPropertyId = 6, ProductId = 1, ProductThemeId = 2, ProductColorId = 1, ProductHeightId = 32, ProductSizeId = 2, Price = 269.99, Title = "Jake Black Berlin Jean Pants", Description = "Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection\nNew Items\nRegular Rise\nSkinny\nSlim Leg\n98% Cotton 2% Elastan\nBlack" }

                );
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage() { ImageId = 1, ProductPropertyId = 1, Title = "", Url = "https://sky-static.mavi.com/sys-master/maviTrImages/hb4/h73/9320593162270/0042230560_image_1.jpg_Default-ZoomProductImage" },
                new ProductImage() { ImageId = 2, ProductPropertyId = 2, Title = "", Url = "https://sky-static.mavi.com/sys-master/maviTrImages/h40/h17/9320592539678/0042230560_image_2.jpg_Default-MainProductImage" },
                new ProductImage() { ImageId = 3, ProductPropertyId = 3, Title = "", Url = "https://sky-static.mavi.com/sys-master/maviTrImages/h8c/h21/9206049013790/0042223856_image_1.jpg_Default-ZoomProductImage" },
                new ProductImage() { ImageId = 4, ProductPropertyId = 4, Title = "", Url = "https://sky-static.mavi.com/sys-master/maviTrImages/hc1/h6d/9313162428446/0042226971_image_1.jpg_Default-ZoomProductImage" }
                ); ;
        }
    }
}
