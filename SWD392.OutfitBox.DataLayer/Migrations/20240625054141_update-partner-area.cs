using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatepartnerarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Area",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Linh Trung");

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Dong Hoa");

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 12, 41, 41, 262, DateTimeKind.Local).AddTicks(1217), new DateTime(2024, 7, 25, 12, 41, 41, 262, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 25, 12, 41, 41, 262, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 25, 12, 41, 41, 262, DateTimeKind.Local).AddTicks(1264));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Area");

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 12, 34, 53, 710, DateTimeKind.Local).AddTicks(3568), new DateTime(2024, 7, 25, 12, 34, 53, 710, DateTimeKind.Local).AddTicks(3583) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 25, 12, 34, 53, 710, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 25, 12, 34, 53, 710, DateTimeKind.Local).AddTicks(3615));
        }
    }
}
