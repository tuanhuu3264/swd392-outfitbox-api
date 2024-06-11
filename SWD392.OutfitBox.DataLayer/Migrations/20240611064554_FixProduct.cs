using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 11, 13, 45, 54, 630, DateTimeKind.Local).AddTicks(9208), new DateTime(2024, 7, 11, 13, 45, 54, 630, DateTimeKind.Local).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 11, 13, 45, 54, 630, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 11, 13, 45, 54, 630, DateTimeKind.Local).AddTicks(9272));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 10, 20, 54, 42, 970, DateTimeKind.Local).AddTicks(338), new DateTime(2024, 7, 10, 20, 54, 42, 970, DateTimeKind.Local).AddTicks(364) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 10, 20, 54, 42, 970, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Color", "Status" },
                values: new object[] { "Blue", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Color", "Status" },
                values: new object[] { "Grey", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Color", "Status" },
                values: new object[] { "Black", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Color", "Status" },
                values: new object[] { "White", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Color", "Status" },
                values: new object[] { "Black", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Color", "Status" },
                values: new object[] { "Pink", "1" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Color", "Status" },
                values: new object[] { "White", "1" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 10, 20, 54, 42, 970, DateTimeKind.Local).AddTicks(505));
        }
    }
}
