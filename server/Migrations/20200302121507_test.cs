using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basket_product_property_ProductProperyProductPropertId",
                table: "basket");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_OrderId",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_product_property_ProductProperyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_ProductProperyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_basket_ProductProperyProductPropertId",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "ProductProperyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "ProductProperyProductPropertId",
                table: "basket");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "order_detail",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductPropertyProductPropertId",
                table: "order_detail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductPropertyProductPropertId",
                table: "basket",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 7L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 8L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 9L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 10L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 11L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 12L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 13L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 14L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 15L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 16L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 6L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 174, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 178, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 178, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 178, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 178, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 178, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 6L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 7L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 8L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 9L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 10L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 11L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 12L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 13L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 14L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 15L,
                column: "DateAdded",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "product_trotter",
                keyColumn: "ProductTrotterId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "product_trotter",
                keyColumn: "ProductTrotterId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 175, DateTimeKind.Utc).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 177, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "sub_categories",
                keyColumn: "SubCategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "sub_categories",
                keyColumn: "SubCategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 3, 2, 12, 15, 6, 176, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTime(2020, 3, 2, 12, 15, 5, 786, DateTimeKind.Utc).AddTicks(848), "$2a$11$nsehHzaMoiLl9TFAJwcH1.a7xv.HrmsQMXmR9Q0ltrIE5ndm2/VLW" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 2L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTime(2020, 3, 2, 12, 15, 5, 986, DateTimeKind.Utc).AddTicks(1549), "$2a$11$PHi0cVc31EAioU.2e5kZR.xn5FXEE2UfFgKiJEBVUo54e7umh9KZe" });

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_ProductPropertyProductPropertId",
                table: "order_detail",
                column: "ProductPropertyProductPropertId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_basket_ProductPropertyProductPropertId",
                table: "basket",
                column: "ProductPropertyProductPropertId");

            migrationBuilder.AddForeignKey(
                name: "FK_basket_product_property_ProductPropertyProductPropertId",
                table: "basket",
                column: "ProductPropertyProductPropertId",
                principalTable: "product_property",
                principalColumn: "ProductPropertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_users_UserId",
                table: "order",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_OrderId",
                table: "order_detail",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_product_property_ProductPropertyProductPropertId",
                table: "order_detail",
                column: "ProductPropertyProductPropertId",
                principalTable: "product_property",
                principalColumn: "ProductPropertId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basket_product_property_ProductPropertyProductPropertId",
                table: "basket");

            migrationBuilder.DropForeignKey(
                name: "FK_order_users_UserId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_OrderId",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_product_property_ProductPropertyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_ProductPropertyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_UserId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_basket_ProductPropertyProductPropertId",
                table: "basket");

            migrationBuilder.DropColumn(
                name: "ProductPropertyProductPropertId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "ProductPropertyProductPropertId",
                table: "basket");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "order_detail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ProductProperyProductPropertId",
                table: "order_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductProperyProductPropertId",
                table: "basket",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "CategoryId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 7L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 8L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 9L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 10L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 11L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 12L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 13L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 14L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 15L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "child_categories",
                keyColumn: "ChildCategoryId",
                keyValue: 16L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "product_colors",
                keyColumn: "ProductColorId",
                keyValue: 6L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 508, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "product_height",
                keyColumn: "ProductHeightId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 513, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 514, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 514, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 514, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 514, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "product_property",
                keyColumn: "ProductPropertId",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 514, DateTimeKind.Utc).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 1L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 2L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 3L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 4L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 5L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 6L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 7L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 8L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 9L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 10L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 11L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 12L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 13L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 14L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "product_size",
                keyColumn: "ProductSizeId",
                keyValue: 15L,
                column: "DateAdded",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 509, DateTimeKind.Utc).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "product_theme",
                keyColumn: "ProductThemeId",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "product_trotter",
                keyColumn: "ProductTrotterId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 510, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "product_trotter",
                keyColumn: "ProductTrotterId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 513, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "sub_categories",
                keyColumn: "SubCategoryId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 511, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "sub_categories",
                keyColumn: "SubCategoryId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2020, 2, 29, 20, 1, 11, 512, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTime(2020, 2, 29, 20, 1, 11, 77, DateTimeKind.Utc).AddTicks(6522), "$2a$11$ukxnHSLE3Vu/S6sWx2ck3uKCIKKx.zgzGNaKVRiD8kGrhOMJi4xBi" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 2L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTime(2020, 2, 29, 20, 1, 11, 307, DateTimeKind.Utc).AddTicks(3132), "$2a$11$d7.zXLVzjLFuPgz86oRg3.uVhQLIo52XNXIFwmUYi4C6kIVFviAPK" });

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_ProductProperyProductPropertId",
                table: "order_detail",
                column: "ProductProperyProductPropertId");

            migrationBuilder.CreateIndex(
                name: "IX_basket_ProductProperyProductPropertId",
                table: "basket",
                column: "ProductProperyProductPropertId");

            migrationBuilder.AddForeignKey(
                name: "FK_basket_product_property_ProductProperyProductPropertId",
                table: "basket",
                column: "ProductProperyProductPropertId",
                principalTable: "product_property",
                principalColumn: "ProductPropertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_OrderId",
                table: "order_detail",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_product_property_ProductProperyProductPropertId",
                table: "order_detail",
                column: "ProductProperyProductPropertId",
                principalTable: "product_property",
                principalColumn: "ProductPropertId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
