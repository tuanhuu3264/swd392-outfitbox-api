using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamagedLevel",
                table: "ProductReturnOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4161), new DateTime(2024, 8, 14, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 15, 17, 43, 37, 867, DateTimeKind.Local).AddTicks(4200));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamagedLevel",
                table: "ProductReturnOrders");

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
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 14, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(225), new DateTime(2024, 8, 13, 20, 31, 51, 190, DateTimeKind.Local).AddTicks(226) });

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
    }
}
