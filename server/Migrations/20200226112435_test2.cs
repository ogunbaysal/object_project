using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_propery_products_ProductId",
                table: "product_propery");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "product_propery",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_propery_products_ProductId",
                table: "product_propery",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_propery_products_ProductId",
                table: "product_propery");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "product_propery",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_product_propery_products_ProductId",
                table: "product_propery",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
