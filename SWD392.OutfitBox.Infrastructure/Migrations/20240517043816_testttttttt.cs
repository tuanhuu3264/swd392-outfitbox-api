using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testttttttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_IdType",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "ProductType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "5");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "1");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "2");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "3");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "4");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "5");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "6");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_IdType",
                table: "Product",
                column: "IdType",
                principalTable: "ProductType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_IdType",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_IdType",
                table: "Product",
                column: "IdType",
                principalTable: "Type",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
