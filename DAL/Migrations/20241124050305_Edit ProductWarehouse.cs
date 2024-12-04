using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EditProductWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouse_Product_productsProduct_Id",
                table: "ProductWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouse_Warehouse_warehousesWarehouse_Id",
                table: "ProductWarehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductWarehouse",
                table: "ProductWarehouse");

            migrationBuilder.RenameColumn(
                name: "warehousesWarehouse_Id",
                table: "ProductWarehouse",
                newName: "Warehouse_Id");

            migrationBuilder.RenameColumn(
                name: "productsProduct_Id",
                table: "ProductWarehouse",
                newName: "Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWarehouse_warehousesWarehouse_Id",
                table: "ProductWarehouse",
                newName: "IX_ProductWarehouse_Warehouse_Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Capacaty",
                table: "Warehouse",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ProductWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ProductWarehouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductWarehouse",
                table: "ProductWarehouse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouse_Product_Id",
                table: "ProductWarehouse",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouse_Product_Product_Id",
                table: "ProductWarehouse",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouse_Warehouse_Warehouse_Id",
                table: "ProductWarehouse",
                column: "Warehouse_Id",
                principalTable: "Warehouse",
                principalColumn: "Warehouse_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouse_Product_Product_Id",
                table: "ProductWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouse_Warehouse_Warehouse_Id",
                table: "ProductWarehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductWarehouse",
                table: "ProductWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_ProductWarehouse_Product_Id",
                table: "ProductWarehouse");

            migrationBuilder.DropColumn(
                name: "Capacaty",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductWarehouse");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProductWarehouse");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ProductWarehouse");

            migrationBuilder.RenameColumn(
                name: "Warehouse_Id",
                table: "ProductWarehouse",
                newName: "warehousesWarehouse_Id");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "ProductWarehouse",
                newName: "productsProduct_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWarehouse_Warehouse_Id",
                table: "ProductWarehouse",
                newName: "IX_ProductWarehouse_warehousesWarehouse_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductWarehouse",
                table: "ProductWarehouse",
                columns: new[] { "productsProduct_Id", "warehousesWarehouse_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouse_Product_productsProduct_Id",
                table: "ProductWarehouse",
                column: "productsProduct_Id",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouse_Warehouse_warehousesWarehouse_Id",
                table: "ProductWarehouse",
                column: "warehousesWarehouse_Id",
                principalTable: "Warehouse",
                principalColumn: "Warehouse_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
