using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seedBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "Description", "ImageUrl", "IsFeatured", "Name", "Status" },
                values: new object[,]
                {
                    { 5, "Uniqlo LLC is a Japanese casual wear design, apparel, and retail company.", "https://upload.wikimedia.org/wikipedia/commons/9/92/UNIQLO_logo.svg", false, "Uniqlo", 1 },
                    { 6, "Zara is a Spanish clothing and accessories brand", "https://img.salehere.co.th/p/1200x0/2024/02/16/gdlpd8hwxiob.jpg", false, "Zara", 1 },
                    { 7, "Famous Spanish fashion brand Pull&Bear.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgJ2G23IAT9jiabKjH8VZ09gtj9BRXH2kCsA&s", false, "Pull&bear", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8954), new DateTime(2024, 8, 13, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8955) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 14, 20, 27, 40, 94, DateTimeKind.Local).AddTicks(8987));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "Description", "ImageUrl", "IsFeatured", "Name", "Status" },
                values: new object[] { 4, "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style", "https://file.hstatic.net/1000003969/file/logo-svg.svg", false, "JUNO", 1 });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6763), new DateTime(2024, 8, 12, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6815));
        }
    }
}
