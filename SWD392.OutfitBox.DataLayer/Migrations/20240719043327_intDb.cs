using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class intDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5706), new DateTime(2024, 8, 18, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "DateTransaction" },
                values: new object[] { null, new DateTime(2024, 7, 19, 11, 33, 27, 150, DateTimeKind.Local).AddTicks(5758) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Transactions");

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
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 17, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8790), new DateTime(2024, 8, 16, 19, 59, 11, 954, DateTimeKind.Local).AddTicks(8791) });

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
    }
}
