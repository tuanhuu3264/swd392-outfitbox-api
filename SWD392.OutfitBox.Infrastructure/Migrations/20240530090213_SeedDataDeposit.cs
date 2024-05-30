using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD392.OutfitBox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distrinct",
                table: "Area",
                newName: "District");

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "City", "District" },
                values: new object[,]
                {
                    { 1, "Ho Chi Minh", "Thu Duc" },
                    { 2, "Binh Duong", "Di An" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Email", "MoneyInWallet", "Name", "OTP", "Password", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "Dong Nai", "Khanhvhdse173550@fpt.edu.vn", 1000L, "Khanh Sky", 111111L, "123456", "0325739910", 1 },
                    { 2, "HCM", "User2@gmail.com", 100L, "User2", 222222L, "123456", "123", 1 },
                    { 3, "HCM", "User3@gmail.com", 100L, "User3", 333333L, "123456", "123", 1 },
                    { 4, "HCM", "User4gmail.com", 100L, "User4", 444444L, "123456", "123", 1 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "AmountMoney", "CustomerId", "Date", "Type" },
                values: new object[] { 1, 20L, 1, new DateTime(2024, 5, 30, 16, 2, 12, 893, DateTimeKind.Local).AddTicks(3641), "Khuyen Mai" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Address", "AreaId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "https://www.grab.com/vn/express/", 1, "Grap@gmail.com", "Grap", "123456" },
                    { 2, "https://be.com.vn/", 1, "Grap@gmail.com", "Bee", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CustomerId", "Status", "WalletCode", "WalletName", "WalletPassword" },
                values: new object[] { 1, 1, 1, "123", "Momo", "123" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "DateTransaction", "DepositId", "WalletId" },
                values: new object[] { 1, new DateTime(2024, 5, 30, 16, 2, 12, 893, DateTimeKind.Local).AddTicks(3614), 1, 1 });

            migrationBuilder.InsertData(
                table: "CustomerPackage",
                columns: new[] { "Id", "CustomerId", "DateFrom", "DateTo", "PackageId", "PackageName", "Price", "ReceiverAddress", "ReceiverName", "ReceiverPhone", "Status", "TransactionId" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 30, 16, 2, 12, 893, DateTimeKind.Local).AddTicks(3566), new DateTime(2024, 6, 29, 16, 2, 12, 893, DateTimeKind.Local).AddTicks(3582), 1, "Newcomer Trial", 200.0, "Nha Van Hoa Sinh Vien", "Khanh Sky", "0325739910", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Area",
                newName: "Distrinct");
        }
    }
}
