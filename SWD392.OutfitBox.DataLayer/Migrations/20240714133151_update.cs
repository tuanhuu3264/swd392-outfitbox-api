using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReturnedDeposit",
                table: "CustomerPackage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ReturnDeposit",
                table: "CustomerPackage",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "IsReturnedDeposit", "ReturnDeposit" },
                values: new object[] { new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(225), new DateTime(2024, 8, 13, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(226), false, 0.0 });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(280));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturnedDeposit",
                table: "CustomerPackage");

            migrationBuilder.DropColumn(
                name: "ReturnDeposit",
                table: "CustomerPackage");

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
