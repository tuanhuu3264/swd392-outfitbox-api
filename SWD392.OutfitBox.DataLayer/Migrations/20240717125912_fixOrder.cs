using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateGive",
                table: "ItemInUserPackages");

            migrationBuilder.DropColumn(
                name: "DateReceive",
                table: "ItemInUserPackages");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ReturnOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "CustomerPackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "OrderCode" },
                values: new object[] { new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8790), new DateTime(2024, 8, 16, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8791), null });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8820));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "CustomerPackage");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ReturnOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateGive",
                table: "ItemInUserPackages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceive",
                table: "ItemInUserPackages",
                type: "datetime2",
                nullable: true);

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
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 17, 19, 0, 49, 487, DateTimeKind.Local).AddTicks(344));
        }
    }
}
