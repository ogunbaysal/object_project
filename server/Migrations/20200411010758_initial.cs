using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "product_colors",
                columns: table => new
                {
                    ProductColorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_colors", x => x.ProductColorId);
                });

            migrationBuilder.CreateTable(
                name: "product_height",
                columns: table => new
                {
                    ProductHeightId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_height", x => x.ProductHeightId);
                });

            migrationBuilder.CreateTable(
                name: "product_size",
                columns: table => new
                {
                    ProductSizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_size", x => x.ProductSizeId);
                });

            migrationBuilder.CreateTable(
                name: "product_theme",
                columns: table => new
                {
                    ProductThemeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_theme", x => x.ProductThemeId);
                });

            migrationBuilder.CreateTable(
                name: "product_trotter",
                columns: table => new
                {
                    ProductTrotterId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_trotter", x => x.ProductTrotterId);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    ProvinceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "sub_categories",
                columns: table => new
                {
                    SubCategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    ParentCategoryId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_categories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_sub_categories_category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    DistrictId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_district_province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child_categories",
                columns: table => new
                {
                    ChildCategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    SubCategoryId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child_categories", x => x.ChildCategoryId);
                    table.ForeignKey(
                        name: "FK_child_categories_sub_categories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "sub_categories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TrackCode = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_order_district_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "district",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildCategoryId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_child_categories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "child_categories",
                        principalColumn: "ChildCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_property",
                columns: table => new
                {
                    ProductPropertyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    ProductColorId = table.Column<long>(nullable: true),
                    ProductHeightId = table.Column<long>(nullable: true),
                    ProductSizeId = table.Column<long>(nullable: true),
                    ProductThemeId = table.Column<long>(nullable: false),
                    ProductTrotterId = table.Column<long>(nullable: true),
                    StockCount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_property", x => x.ProductPropertyId);
                    table.ForeignKey(
                        name: "FK_product_property_product_colors_ProductColorId",
                        column: x => x.ProductColorId,
                        principalTable: "product_colors",
                        principalColumn: "ProductColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_property_product_height_ProductHeightId",
                        column: x => x.ProductHeightId,
                        principalTable: "product_height",
                        principalColumn: "ProductHeightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_property_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_property_product_size_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "product_size",
                        principalColumn: "ProductSizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_property_product_theme_ProductThemeId",
                        column: x => x.ProductThemeId,
                        principalTable: "product_theme",
                        principalColumn: "ProductThemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_property_product_trotter_ProductTrotterId",
                        column: x => x.ProductTrotterId,
                        principalTable: "product_trotter",
                        principalColumn: "ProductTrotterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "basket",
                columns: table => new
                {
                    BasketId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPropertyId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basket", x => x.BasketId);
                    table.ForeignKey(
                        name: "FK_basket_product_property_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "product_property",
                        principalColumn: "ProductPropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_basket_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    OrderDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ProductPropertyId = table.Column<long>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_order_detail_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_detail_product_property_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "product_property",
                        principalColumn: "ProductPropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_images",
                columns: table => new
                {
                    ImageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    ProductPropertyId = table.Column<long>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_product_images_product_property_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "product_property",
                        principalColumn: "ProductPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "CategoryId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(5047), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "woman", 1, "Women" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(7350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "men", 1, "Men" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(7469), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "child", 1, "Child" },
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(7472), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "outlet", 1, "Outlet" }
                });

            migrationBuilder.InsertData(
                table: "product_colors",
                columns: new[] { "ProductColorId", "DateAdded", "DateModified", "Status", "Tag", "Url" },
                values: new object[,]
                {
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Black", "site.com/black" },
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(3007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Blue", "site.com/blue" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6486), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Red", "site.com/red" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Green", "site.com/green" },
                    { 7L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Navy", "site.com/navy" },
                    { 5L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "White", "site.com/white" },
                    { 6L, new DateTime(2020, 4, 11, 1, 7, 57, 214, DateTimeKind.Utc).AddTicks(6727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Purple", "site.com/purple" }
                });

            migrationBuilder.InsertData(
                table: "product_height",
                columns: new[] { "ProductHeightId", "DateAdded", "DateModified", "Status", "Title" },
                values: new object[,]
                {
                    { 36L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(3949), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "36" },
                    { 32L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(3889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "32" },
                    { 30L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(3799), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "30" },
                    { 28L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(1748), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "28" },
                    { 34L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(3920), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34" }
                });

            migrationBuilder.InsertData(
                table: "product_size",
                columns: new[] { "ProductSizeId", "DateAdded", "DateModified", "Status", "Title" },
                values: new object[,]
                {
                    { 12L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "30" },
                    { 13L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "32" },
                    { 14L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9697), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34" },
                    { 11L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9608), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "28" },
                    { 15L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "36" },
                    { 10L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "26" },
                    { 9L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9552), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "24" },
                    { 8L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXXL" },
                    { 7L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXL" },
                    { 6L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XL" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XS" },
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "M" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "S" },
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(7679), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXS" },
                    { 5L, new DateTime(2020, 4, 11, 1, 7, 57, 215, DateTimeKind.Utc).AddTicks(9405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "L" }
                });

            migrationBuilder.InsertData(
                table: "product_theme",
                columns: new[] { "ProductThemeId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(5923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "smart", 0, "Smart" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(5866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "season-sale", 0, "Season Sale" },
                    { 5L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(5925), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mavi-black", 0, "Mavi Black" },
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(3499), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-items", 0, "New Items" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(5920), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mavi-logo", 0, "Mavi Logo" }
                });

            migrationBuilder.InsertData(
                table: "product_trotter",
                columns: new[] { "ProductTrotterId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 216, DateTimeKind.Utc).AddTicks(9252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "long-sleeve", 0, "Long Sleeve" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(1509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "short-sleeve", 0, "Short Sleeve" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 217, DateTimeKind.Utc).AddTicks(1568), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "slim-leg", 0, "Slim Leg" }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "ProvinceId", "Title" },
                values: new object[,]
                {
                    { 77L, "Yalova" },
                    { 35L, "İzmir" },
                    { 9L, "Ankara" },
                    { 34L, "İstanbul" },
                    { 48L, "Muğla" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "DateCreated", "DateModified", "Email", "Firstname", "Lastname", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 56, 733, DateTimeKind.Utc).AddTicks(2050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@ogun.me", "Ogün", "Baysal", "$2a$11$tr/fJBKLvncmwHvTbSl30.kh7GkU5yzzkfKu9KbxwYdvJx67wlYEy", "Admin", null, "Admin" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 56, 980, DateTimeKind.Utc).AddTicks(8139), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ozgur.durak@yandex.com", "Özgür", "Durak", "$2a$11$SzSRLdcoEd268w8eidVo4OVnSxT.3ml9t/3k2kqTJjhWub3c7qYiK", "User", null, "ozgurdurak" }
                });

            migrationBuilder.InsertData(
                table: "district",
                columns: new[] { "DistrictId", "ProvinceId", "Title" },
                values: new object[,]
                {
                    { 1L, 77L, "Merkez" },
                    { 2L, 77L, "Termal" },
                    { 3L, 77L, "Çınarcık" },
                    { 4L, 34L, "Pendik" },
                    { 5L, 34L, "Kartal" }
                });

            migrationBuilder.InsertData(
                table: "sub_categories",
                columns: new[] { "SubCategoryId", "DateCreated", "DateModified", "ParentCategoryId", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "clothes", 1, "Clothes" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(3547), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "accessories", 1, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "child_categories",
                columns: new[] { "ChildCategoryId", "DateCreated", "DateModified", "Slug", "Status", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(6715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "denim", 1, 1L, "Denim" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9566), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shirts", 1, 1L, "Shirts" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "t-shirts", 1, 1L, "T-Shirts" },
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9639), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "basics", 1, 1L, "Basics" },
                    { 5L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9641), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sweatshirts", 1, 1L, "Sweatshirts" },
                    { 6L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9643), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "coat-jacket", 1, 1L, "Coat - Jacket" },
                    { 7L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9645), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pants", 1, 1L, "Pants" },
                    { 8L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9647), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "knitwear-sweaters", 1, 1L, "Knitwear-Sweaters" },
                    { 9L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bags-wallets", 1, 2L, "Bags-Wallets" },
                    { 10L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "parfume", 1, 2L, "Parfume" },
                    { 11L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "belt", 1, 2L, "Belt" },
                    { 12L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "scarf-beret", 1, 2L, "Scarf-Beret" },
                    { 13L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9656), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hats", 1, 2L, "Hats" },
                    { 14L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9658), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "boxer", 1, 2L, "Boxer" },
                    { 15L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "socks", 1, 2L, "Socks" },
                    { 16L, new DateTime(2020, 4, 11, 1, 7, 57, 218, DateTimeKind.Utc).AddTicks(9661), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "boxer", 1, 2L, "Boxer" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "ChildCategoryId", "DateCreated", "DateModified", "Description", "Status", "Title" },
                values: new object[] { 1L, 1L, new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normal Bel, Skinny", 0, "JAKE" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "ChildCategoryId", "DateCreated", "DateModified", "Description", "Status", "Title" },
                values: new object[] { 2L, 2L, new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "James Black Pro Gölge Mavi Jean Pantolon" });

            migrationBuilder.InsertData(
                table: "product_property",
                columns: new[] { "ProductPropertyId", "DateCreated", "DateModified", "Description", "Price", "ProductColorId", "ProductHeightId", "ProductId", "ProductSizeId", "ProductThemeId", "ProductTrotterId", "StockCount", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(1039), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection", 269.99000000000001, 7L, 32L, 1L, null, 1L, null, 0, "Jake Vintage Ink Mavi Jet Black Jean Pants" },
                    { 11L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(6840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection", 269.99000000000001, 7L, 34L, 1L, null, 1L, null, 0, "Jake Vintage Ink Mavi Jet Black Jean Pants" },
                    { 12L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(7046), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection", 169.99000000000001, 5L, 32L, 1L, null, 1L, null, 0, "Jake Vintage Ink Mavi Jet Black Jean Pants" },
                    { 13L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(7051), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover Jake Vintage Ink Mavi Jet Black Jean Pants from Mavi's Men' Collection", 169.99000000000001, 5L, 34L, 1L, null, 1L, null, 0, "Jake Vintage Ink Mavi Jet Black Jean Pants" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(7054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 269.99000000000001, 3L, 32L, 1L, 2L, 1L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(7951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 269.99000000000001, 4L, 32L, 1L, 2L, 1L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 6L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(8845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 269.99000000000001, 1L, 32L, 1L, 2L, 2L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(7984), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 269.99000000000001, 2L, 32L, 2L, 1L, 2L, 1L, 0, "Jake Black Berlin Jean Pants" },
                    { 5L, new DateTime(2020, 4, 11, 1, 7, 57, 220, DateTimeKind.Utc).AddTicks(8818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 269.99000000000001, 2L, 32L, 2L, 1L, 2L, 2L, 0, "Jake Black Berlin Jean Pants" }
                });

            migrationBuilder.InsertData(
                table: "product_images",
                columns: new[] { "ImageId", "DateAdded", "DateModified", "ProductPropertyId", "Title", "Url" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 4, 11, 1, 7, 57, 221, DateTimeKind.Utc).AddTicks(805), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "", "https://sky-static.mavi.com/sys-master/maviTrImages/hb4/h73/9320593162270/0042230560_image_1.jpg_Default-ZoomProductImage" },
                    { 2L, new DateTime(2020, 4, 11, 1, 7, 57, 221, DateTimeKind.Utc).AddTicks(3300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "", "https://sky-static.mavi.com/sys-master/maviTrImages/h40/h17/9320592539678/0042230560_image_2.jpg_Default-MainProductImage" },
                    { 3L, new DateTime(2020, 4, 11, 1, 7, 57, 221, DateTimeKind.Utc).AddTicks(3355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "", "https://sky-static.mavi.com/sys-master/maviTrImages/h8c/h21/9206049013790/0042223856_image_1.jpg_Default-ZoomProductImage" },
                    { 4L, new DateTime(2020, 4, 11, 1, 7, 57, 221, DateTimeKind.Utc).AddTicks(3358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "", "https://sky-static.mavi.com/sys-master/maviTrImages/hc1/h6d/9313162428446/0042226971_image_1.jpg_Default-ZoomProductImage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_basket_ProductPropertyId",
                table: "basket",
                column: "ProductPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_basket_UserId",
                table: "basket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_child_categories_SubCategoryId",
                table: "child_categories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_district_ProvinceId",
                table: "district",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_order_DistrictId",
                table: "order",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_OrderId",
                table: "order_detail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_ProductPropertyId",
                table: "order_detail",
                column: "ProductPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductPropertyId",
                table: "product_images",
                column: "ProductPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductColorId",
                table: "product_property",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductHeightId",
                table: "product_property",
                column: "ProductHeightId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductId",
                table: "product_property",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductSizeId",
                table: "product_property",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductThemeId",
                table: "product_property",
                column: "ProductThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_ProductTrotterId",
                table: "product_property",
                column: "ProductTrotterId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ChildCategoryId",
                table: "products",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_categories_ParentCategoryId",
                table: "sub_categories",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basket");

            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "product_images");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product_property");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "product_colors");

            migrationBuilder.DropTable(
                name: "product_height");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product_size");

            migrationBuilder.DropTable(
                name: "product_theme");

            migrationBuilder.DropTable(
                name: "product_trotter");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "child_categories");

            migrationBuilder.DropTable(
                name: "sub_categories");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
