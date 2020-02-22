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
                    DateMofied = table.Column<DateTime>(nullable: false)
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
                    DateMofied = table.Column<DateTime>(nullable: false)
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
                    DateMofied = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_trotter", x => x.ProductTrotterId);
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
                    DateMofied = table.Column<DateTime>(nullable: false)
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
                    ParentCategoryCategoryId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateMofied = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_categories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_sub_categories_category_ParentCategoryCategoryId",
                        column: x => x.ParentCategoryCategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ProductSizeId = table.Column<long>(nullable: true),
                    ProductThemeId = table.Column<long>(nullable: true),
                    ProductTrotterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_product_size_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "product_size",
                        principalColumn: "ProductSizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_product_theme_ProductThemeId",
                        column: x => x.ProductThemeId,
                        principalTable: "product_theme",
                        principalColumn: "ProductThemeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_product_trotter_ProductTrotterId",
                        column: x => x.ProductTrotterId,
                        principalTable: "product_trotter",
                        principalColumn: "ProductTrotterId",
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
                    DateModified = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "ProductProductColors",
                columns: table => new
                {
                    CrossId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    ProductColorId = table.Column<long>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductColors", x => x.CrossId);
                    table.ForeignKey(
                        name: "FK_ProductProductColors_product_colors_ProductColorId",
                        column: x => x.ProductColorId,
                        principalTable: "product_colors",
                        principalColumn: "ProductColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductColors_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductHeights",
                columns: table => new
                {
                    CrossId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    ProductHeightId = table.Column<long>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductHeights", x => x.CrossId);
                    table.ForeignKey(
                        name: "FK_ProductProductHeights_product_height_ProductHeightId",
                        column: x => x.ProductHeightId,
                        principalTable: "product_height",
                        principalColumn: "ProductHeightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductHeights_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductSizes",
                columns: table => new
                {
                    CrossId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    ProductSizeId = table.Column<long>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSizes", x => x.CrossId);
                    table.ForeignKey(
                        name: "FK_ProductProductSizes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSizes_product_size_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "product_size",
                        principalColumn: "ProductSizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductThemes",
                columns: table => new
                {
                    CrossId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    ProductThemeId = table.Column<long>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductThemes", x => x.CrossId);
                    table.ForeignKey(
                        name: "FK_ProductProductThemes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductThemes_product_theme_ProductThemeId",
                        column: x => x.ProductThemeId,
                        principalTable: "product_theme",
                        principalColumn: "ProductThemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductTrotters",
                columns: table => new
                {
                    CrossId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    ProductTrotterId = table.Column<long>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductTrotters", x => x.CrossId);
                    table.ForeignKey(
                        name: "FK_ProductProductTrotters_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductTrotters_product_trotter_ProductTrotterId",
                        column: x => x.ProductTrotterId,
                        principalTable: "product_trotter",
                        principalColumn: "ProductTrotterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_images_ProductId",
                table: "product_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductColors_ProductColorId",
                table: "ProductProductColors",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductColors_ProductId",
                table: "ProductProductColors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductHeights_ProductHeightId",
                table: "ProductProductHeights",
                column: "ProductHeightId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductHeights_ProductId",
                table: "ProductProductHeights",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSizes_ProductId",
                table: "ProductProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSizes_ProductSizeId",
                table: "ProductProductSizes",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductThemes_ProductId",
                table: "ProductProductThemes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductThemes_ProductThemeId",
                table: "ProductProductThemes",
                column: "ProductThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTrotters_ProductId",
                table: "ProductProductTrotters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTrotters_ProductTrotterId",
                table: "ProductProductTrotters",
                column: "ProductTrotterId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductSizeId",
                table: "products",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductThemeId",
                table: "products",
                column: "ProductThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTrotterId",
                table: "products",
                column: "ProductTrotterId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_categories_ParentCategoryCategoryId",
                table: "sub_categories",
                column: "ParentCategoryCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_images");

            migrationBuilder.DropTable(
                name: "ProductProductColors");

            migrationBuilder.DropTable(
                name: "ProductProductHeights");

            migrationBuilder.DropTable(
                name: "ProductProductSizes");

            migrationBuilder.DropTable(
                name: "ProductProductThemes");

            migrationBuilder.DropTable(
                name: "ProductProductTrotters");

            migrationBuilder.DropTable(
                name: "sub_categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "product_colors");

            migrationBuilder.DropTable(
                name: "product_height");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "product_size");

            migrationBuilder.DropTable(
                name: "product_theme");

            migrationBuilder.DropTable(
                name: "product_trotter");
        }
    }
}
