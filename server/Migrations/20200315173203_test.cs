﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class test : Migration
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
                    ProductPropertId = table.Column<long>(nullable: false)
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
                    Price = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_property", x => x.ProductPropertId);
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
                        principalColumn: "ProductPropertId",
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
                    ProductPropertyProductPropertId = table.Column<long>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
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
                        name: "FK_order_detail_product_property_ProductPropertyProductPropertId",
                        column: x => x.ProductPropertyProductPropertId,
                        principalTable: "product_property",
                        principalColumn: "ProductPropertId",
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
                    ProductId = table.Column<long>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ProductPropertyProductPropertId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_product_images_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_images_product_property_ProductPropertyProductPropertId",
                        column: x => x.ProductPropertyProductPropertId,
                        principalTable: "product_property",
                        principalColumn: "ProductPropertId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "CategoryId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "woman", 1, "Women" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(1644), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "men", 1, "Men" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(1713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "child", 1, "Child" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(1715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "outlet", 1, "Outlet" }
                });

            migrationBuilder.InsertData(
                table: "product_colors",
                columns: new[] { "ProductColorId", "DateAdded", "DateModified", "Status", "Tag", "Url" },
                values: new object[,]
                {
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(1088), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Black", "site.com/blue" },
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 70, DateTimeKind.Utc).AddTicks(7739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Blue", "site.com/blue" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Red", "site.com/blue" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(1060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Green", "site.com/blue" },
                    { 6L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(1132), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Purple", "site.com/blue" },
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(1110), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "White", "site.com/blue" }
                });

            migrationBuilder.InsertData(
                table: "product_height",
                columns: new[] { "ProductHeightId", "DateAdded", "DateModified", "Status", "Title" },
                values: new object[,]
                {
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(5542), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "36" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(5474), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "32" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(5398), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "30" },
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(3712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "28" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(5509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34" }
                });

            migrationBuilder.InsertData(
                table: "product_size",
                columns: new[] { "ProductSizeId", "DateAdded", "DateModified", "Status", "Title" },
                values: new object[,]
                {
                    { 12L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "30" },
                    { 13L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(637), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "32" },
                    { 14L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(655), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34" },
                    { 11L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(596), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "28" },
                    { 15L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "36" },
                    { 10L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "26" },
                    { 9L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "24" },
                    { 8L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXXL" },
                    { 7L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(470), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXL" },
                    { 6L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(448), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XL" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XS" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "M" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(380), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "S" },
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 71, DateTimeKind.Utc).AddTicks(8861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "XXS" },
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "L" }
                });

            migrationBuilder.InsertData(
                table: "product_theme",
                columns: new[] { "ProductThemeId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(4983), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mavi-logo", 0, "Mavi Logo" },
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(3125), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-items", 0, "New Items" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(4985), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "smart", 0, "Smart" },
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(4986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mavi-black", 0, "Mavi Black" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(4865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "season-sale", 0, "Season Sale" }
                });

            migrationBuilder.InsertData(
                table: "product_trotter",
                columns: new[] { "ProductTrotterId", "DateCreated", "DateModified", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(6928), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "long-sleeve", 0, "Long Sleeve" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 72, DateTimeKind.Utc).AddTicks(8448), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "short-sleeve", 0, "Short Sleeve" }
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
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 2, 624, DateTimeKind.Utc).AddTicks(995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@ogun.me", "Ogün", "Baysal", "$2a$11$y.fnJEzXDma57RXagUgFpu2OTsNUnwipgtp4Akkcz/G05XEDfpe7K", "Admin", null, "Admin" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 2, 861, DateTimeKind.Utc).AddTicks(1455), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ozgur.durak@yandex.com", "Özgür", "Durak", "$2a$11$CI2Q7H8hQJRLKEw3RnQEMOhfZDoo/6x5CI4pDeLS8dNXoA2UJMj2u", "User", null, "ozgurdurak" }
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
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(3389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "clothes", 1, "Clothes" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(5258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "accessories", 1, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "child_categories",
                columns: new[] { "ChildCategoryId", "DateCreated", "DateModified", "Slug", "Status", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(6942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "denim", 1, 1L, "Denim" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9228), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shirts", 1, 1L, "Shirts" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9269), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "t-shirts", 1, 1L, "T-Shirts" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9271), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "basics", 1, 1L, "Basics" },
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sweatshirts", 1, 1L, "Sweatshirts" },
                    { 6L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "coat-jacket", 1, 1L, "Coat - Jacket" },
                    { 7L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9275), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pants", 1, 1L, "Pants" },
                    { 8L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "knitwear-sweaters", 1, 1L, "Knitwear-Sweaters" },
                    { 9L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9277), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bags-wallets", 1, 2L, "Bags-Wallets" },
                    { 10L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "parfume", 1, 2L, "Parfume" },
                    { 11L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "belt", 1, 2L, "Belt" },
                    { 12L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "scarf-beret", 1, 2L, "Scarf-Beret" },
                    { 13L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9282), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hats", 1, 2L, "Hats" },
                    { 14L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9283), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "boxer", 1, 2L, "Boxer" },
                    { 15L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "socks", 1, 2L, "Socks" },
                    { 16L, new DateTime(2020, 3, 15, 17, 32, 3, 73, DateTimeKind.Utc).AddTicks(9286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "boxer", 1, 2L, "Boxer" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "ChildCategoryId", "DateCreated", "DateModified", "Description", "Status", "Title" },
                values: new object[] { 1L, 1L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(1172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "Jake Black Berlin Jean Pants" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "ChildCategoryId", "DateCreated", "DateModified", "Description", "Status", "Title" },
                values: new object[] { 2L, 2L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(3097), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "Jake Black Berlin Jean Pants" });

            migrationBuilder.InsertData(
                table: "product_property",
                columns: new[] { "ProductPropertId", "DateCreated", "DateModified", "Description", "Price", "ProductColorId", "ProductHeightId", "ProductId", "ProductSizeId", "ProductThemeId", "ProductTrotterId", "StockCount", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(5271), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 2L, 2L, 1L, 2L, 1L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 2L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(9805), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 3L, 2L, 1L, 2L, 1L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 3L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(9896), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 4L, 2L, 1L, 2L, 1L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 6L, new DateTime(2020, 3, 15, 17, 32, 3, 75, DateTimeKind.Utc).AddTicks(525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 1L, 2L, 1L, 2L, 2L, null, 0, "Jake Black Berlin Jean Pants" },
                    { 4L, new DateTime(2020, 3, 15, 17, 32, 3, 74, DateTimeKind.Utc).AddTicks(9909), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 2L, 5L, 2L, 1L, 2L, 1L, 0, "Jake Black Berlin Jean Pants" },
                    { 5L, new DateTime(2020, 3, 15, 17, 32, 3, 75, DateTimeKind.Utc).AddTicks(487), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"Discover Jake Black Berlin Jean Pants from Mavi's Men' Collection
                New Items
                Regular Rise
                Skinny
                Slim Leg
                98% Cotton 2% Elastan
                Black", 0f, 2L, 5L, 2L, 1L, 2L, 2L, 0, "Jake Black Berlin Jean Pants" }
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
                name: "IX_order_detail_ProductPropertyProductPropertId",
                table: "order_detail",
                column: "ProductPropertyProductPropertId");

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductId",
                table: "product_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductPropertyProductPropertId",
                table: "product_images",
                column: "ProductPropertyProductPropertId");

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