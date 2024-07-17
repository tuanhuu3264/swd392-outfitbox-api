using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Product_ProductId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Reviews",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_PackageId");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(308), new DateTime(2024, 8, 16, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(308) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 31,
                column: "Link",
                value: "https://cdn.tgdd.vn/Products/Images/7264/313970/casio-mtp-m100d-7avdf-nam-2-1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 32,
                column: "Link",
                value: "https://cdn.tgdd.vn/Products/Images/7264/316403/citizen-em0809-83z-nu-1.jpg");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Packages_PackageId",
                table: "Reviews",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Packages_PackageId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Reviews",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PackageId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8664), new DateTime(2024, 8, 14, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 31,
                column: "Link",
                value: "https://www.thegioididong.com/dong-ho-deo-tay/casio-mtp-m100d-7avdf-nam#top-color-images-gallery-1174");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 32,
                column: "Link",
                value: "https://www.thegioididong.com/dong-ho-deo-tay/citizen-em0809-83z-nu#top-color-images-gallery-15");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Product_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
