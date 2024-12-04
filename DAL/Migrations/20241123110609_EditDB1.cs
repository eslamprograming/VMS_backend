using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EditDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SuppliyProductDetails_ProductSuppliy_ProductSuppliy_Id1",
                table: "SuppliyProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_SuppliyProductDetails_ProductSuppliy_Id1",
                table: "SuppliyProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductSuppliy_Id1",
                table: "SuppliyProductDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliyProductDetails_ProductSuppliy_Id",
                table: "SuppliyProductDetails",
                column: "ProductSuppliy_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_Product_Id",
                table: "OrderDetails",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliyProductDetails_ProductSuppliy_ProductSuppliy_Id",
                table: "SuppliyProductDetails",
                column: "ProductSuppliy_Id",
                principalTable: "ProductSuppliy",
                principalColumn: "ProductSuppliy_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_Product_Id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SuppliyProductDetails_ProductSuppliy_ProductSuppliy_Id",
                table: "SuppliyProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_SuppliyProductDetails_ProductSuppliy_Id",
                table: "SuppliyProductDetails");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Product_Id",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ProductSuppliy_Id1",
                table: "SuppliyProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SuppliyProductDetails_ProductSuppliy_Id1",
                table: "SuppliyProductDetails",
                column: "ProductSuppliy_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliyProductDetails_ProductSuppliy_ProductSuppliy_Id1",
                table: "SuppliyProductDetails",
                column: "ProductSuppliy_Id1",
                principalTable: "ProductSuppliy",
                principalColumn: "ProductSuppliy_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
