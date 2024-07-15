using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class databasetransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VNPayID",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTransaction", "VNPayID" },
                values: new object[] { new DateTime(2024, 7, 15, 23, 41, 4, 819, DateTimeKind.Local).AddTicks(8706), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VNPayID",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8850), new DateTime(2024, 8, 14, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8851) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8886));
        }
    }
}
