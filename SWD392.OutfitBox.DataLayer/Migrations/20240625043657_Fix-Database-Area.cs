using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDatabaseArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "Area",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Y",
                table: "Area",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "X", "Y" },
                values: new object[] { "10.8447022", "106.7618557" });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "X", "Y" },
                values: new object[] { "10.8447022", "106.7618557" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://theme.hstatic.net/200000571545/1000929382/14/logo.png?v=171");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://theme.hstatic.net/1000053720/1001049163/14/logo.png?v=3942");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://panel.outfit4rent.online/images/logo-mark-light.svg");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "Description", "ImageUrl", "IsFeatured", "Name", "Status" },
                values: new object[] { 4, "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style", "https://file.hstatic.net/1000003969/file/logo-svg.svg", false, "JUNO", 1 });

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 25, 11, 36, 56, 504, DateTimeKind.Local).AddTicks(4334), new DateTime(2024, 7, 25, 11, 36, 56, 504, DateTimeKind.Local).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 25, 11, 36, 56, 504, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 25, 11, 36, 56, 504, DateTimeKind.Local).AddTicks(4392));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "X",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Area");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://nosbyn.com/");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://thebluetshirt.com/");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://thebluetshirt.com/");

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
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 6, 11, 13, 45, 54, 630, DateTimeKind.Local).AddTicks(9272));
        }
    }
}
