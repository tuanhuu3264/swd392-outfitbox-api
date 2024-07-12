using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5870), new DateTime(2024, 8, 8, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 13,
                column: "IdBrand",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 9, 12, 53, 54, 547, DateTimeKind.Local).AddTicks(5909));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3889), new DateTime(2024, 8, 8, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 13,
                column: "IdBrand",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 9, 12, 51, 19, 153, DateTimeKind.Local).AddTicks(3921));
        }
    }
}
