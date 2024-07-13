using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ReturnOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerPackageId",
                table: "ReturnOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOfItems",
                table: "ReturnOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalThornMoney",
                table: "ReturnOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductReturnOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ThornMoney",
                table: "ProductReturnOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnedQuantity",
                table: "ItemInUserPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CustomerPackage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://hoangnguyenstore.com/wp-content/uploads/2021/11/ao-so-mi-dior-hoa-tiet-nhen-asmd01-5.webp");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://cf.shopee.vn/file/53ba7e3dcff647db1ff302f6c378a0bc");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://lzd-img-global.slatic.net/g/p/ff217e1a9b75a39108b8a04c22d164dc.jpg_720x720q80.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://image.dhgate.com/0x0s/f2-albu-g17-M00-71-84-rBVa4V_J8_iAXsmWAADRlVU_URo051.jpg/2021-black-ball-gown-gothic-wedding-dresses.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.pinimg.com/originals/47/2c/21/472c21c67c84e2d69866319ccf7906d6.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://d2hg8ctx8thzji.cloudfront.net/clusterfeed.net/wp-content/uploads/2020/07/6CommonlyUsedAccessoriestoChooseFrom-750x532.jpg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://top.chon.vn/wp-content/uploads/2019/09/shop-do-doi-5.jpg");

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
                columns: new[] { "CreatedAt", "DateFrom", "DateTo" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 13, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6763), new DateTime(2024, 8, 12, 10, 55, 30, 511, DateTimeKind.Local).AddTicks(6764) });

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

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_CustomerPackageId",
                table: "ReturnOrders",
                column: "CustomerPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOrders_CustomerPackage_CustomerPackageId",
                table: "ReturnOrders",
                column: "CustomerPackageId",
                principalTable: "CustomerPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOrders_CustomerPackage_CustomerPackageId",
                table: "ReturnOrders");

            migrationBuilder.DropIndex(
                name: "IX_ReturnOrders_CustomerPackageId",
                table: "ReturnOrders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ReturnOrders");

            migrationBuilder.DropColumn(
                name: "CustomerPackageId",
                table: "ReturnOrders");

            migrationBuilder.DropColumn(
                name: "QuantityOfItems",
                table: "ReturnOrders");

            migrationBuilder.DropColumn(
                name: "TotalThornMoney",
                table: "ReturnOrders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductReturnOrders");

            migrationBuilder.DropColumn(
                name: "ThornMoney",
                table: "ProductReturnOrders");

            migrationBuilder.DropColumn(
                name: "ReturnedQuantity",
                table: "ItemInUserPackages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CustomerPackage");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "CustomerPackage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6550), new DateTime(2024, 8, 7, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTransaction",
                value: new DateTime(2024, 7, 8, 17, 3, 22, 173, DateTimeKind.Local).AddTicks(6595));
        }
    }
}
