using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD392.OutfitBox.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MoneyInWallet = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableRentDays = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumOfProduct = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Y = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountMoney = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryPackages_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberStars = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Paymethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    DepositId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewImages_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    QuantityOfItems = table.Column<int>(type: "int", nullable: true),
                    TotalDeposit = table.Column<double>(type: "float", nullable: true),
                    ReturnDeposit = table.Column<double>(type: "float", nullable: false),
                    IsReturnedDeposit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPackage_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerPackage_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPackage_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemInUserPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserPackageId = table.Column<int>(type: "int", nullable: false),
                    DateGive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReceive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TornMoney = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInUserPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInUserPackages_CustomerPackage_UserPackageId",
                        column: x => x.UserPackageId,
                        principalTable: "CustomerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInUserPackages_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QuantityOfItems = table.Column<int>(type: "int", nullable: false),
                    CustomerPackageId = table.Column<int>(type: "int", nullable: false),
                    TotalThornMoney = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnOrders_CustomerPackage_CustomerPackageId",
                        column: x => x.CustomerPackageId,
                        principalTable: "CustomerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnOrders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnOrders_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReturnOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DamagedLevel = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReturnOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ThornMoney = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReturnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReturnOrders_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReturnOrders_ReturnOrders_ReturnOrderId",
                        column: x => x.ReturnOrderId,
                        principalTable: "ReturnOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Address", "City", "District" },
                values: new object[,]
                {
                    { 1, "Linh Trung", "Ho Chi Minh", "Thu Duc" },
                    { 2, "Dong Hoa", "Binh Duong", "Di An" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "Description", "ImageUrl", "IsFeatured", "Name", "Status" },
                values: new object[,]
                {
                    { 1, " Explosive within the Vietnamese fashion community in 2013, Nosbyn captured the hearts of young fashion enthusiasts with its stylish yet basic items. Leading the way were its signature solid-colored crop tops, which remained a prominent fixture even after three years of development. Today, Nosbyn continues to hold a strong position in the hearts of Vietnamese fashionistas.", "https://theme.hstatic.net/200000571545/1000929382/14/logo.png?v=171", false, "NOSBYN", 1 },
                    { 2, "The BlueTshirt, established in 2012, initially introduced simple t-shirt designs with inspiring slogans to the Vietnamese market. The brand's designs strike a perfect balance between elegance and a free-spirited nature, reflecting the personality of its founder. Whether you are a gentle and graceful woman or someone with a strong individualistic style, The BlueTshirt offers a wide range of products to cater to your preferences.", "https://theme.hstatic.net/1000053720/1001049163/14/logo.png?v=3942", false, "THE BLUE T-SHIRT", 1 },
                    { 3, "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style", "https://panel.outfit4rent.online/images/logo-mark-light.svg", false, "OUTFIT4RENT", 1 },
                    { 4, "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style", "https://file.hstatic.net/1000003969/file/logo-svg.svg", false, "JUNO", 1 },
                    { 5, "Uniqlo LLC is a Japanese casual wear design, apparel, and retail company.", "https://upload.wikimedia.org/wikipedia/commons/9/92/UNIQLO_logo.svg", false, "Uniqlo", 1 },
                    { 6, "Zara is a Spanish clothing and accessories brand.", "https://img.salehere.co.th/p/1200x0/2024/02/16/gdlpd8hwxiob.jpg", false, "Zara", 1 },
                    { 7, "Famous Spanish fashion brand Pull&Bear.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgJ2G23IAT9jiabKjH8VZ09gtj9BRXH2kCsA&s", false, "Pull&Bear", 1 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Description", "ImageUrl", "IsFeatured", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "T-Shirt,Vest,Polo,Smock,...", "https://hoangnguyenstore.com/wp-content/uploads/2021/11/ao-so-mi-dior-hoa-tiet-nhen-asmd01-5.webp", false, "Shirt", 0 },
                    { 2, "Gauchos,Jeans,Trousers,...", "https://cf.shopee.vn/file/53ba7e3dcff647db1ff302f6c378a0bc", false, "Short", 0 },
                    { 3, "Skater,Circle,Aline,Maxi,Sarong,...", "https://lzd-img-global.slatic.net/g/p/ff217e1a9b75a39108b8a04c22d164dc.jpg_720x720q80.jpg", false, "Skirt", 0 },
                    { 4, "A-line,Empire,Tent,Princess,Shift,...", "https://image.dhgate.com/0x0s/f2-albu-g17-M00-71-84-rBVa4V_J8_iAXsmWAADRlVU_URo051.jpg/2021-black-ball-gown-gothic-wedding-dresses.jpg", false, "Dress", 0 },
                    { 5, "Ao dai,Traditional clothers,...", "https://i.pinimg.com/originals/47/2c/21/472c21c67c84e2d69866319ccf7906d6.jpg", false, "Costumes", 0 },
                    { 6, "Sunglasses,Tie,Watch,Bow,...", "https://d2hg8ctx8thzji.cloudfront.net/clusterfeed.net/wp-content/uploads/2020/07/6CommonlyUsedAccessoriestoChooseFrom-750x532.jpg", false, "Accessories", 0 },
                    { 7, "Way for couples or friends to express their affection and bond with each other", "https://top.chon.vn/wp-content/uploads/2019/09/shop-do-doi-5.jpg", false, "Couple", 0 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Email", "MoneyInWallet", "Name", "Phone", "Picture", "Status", "Time" },
                values: new object[,]
                {
                    { 1, "Dong Nai", "Khanhvhdse173550@fpt.edu.vn", 1000L, "Khanh Sky", "0325739910", "", 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8764) },
                    { 2, "HCM", "User2@gmail.com", 100L, "User2", "123", "", 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8789) },
                    { 3, "HCM", "User3@gmail.com", 100L, "User3", "123", "", 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8791) },
                    { 4, "HCM", "User4gmail.com", 100L, "User4", "123", "", 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8792) }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "AvailableRentDays", "Description", "ImageUrl", "IsFeatured", "Name", "NumOfProduct", "Price", "Status" },
                values: new object[,]
                {
                    { 1, 30, "The new customer can use to experience, with total 4 product in 4 category: Shirt,Short,Skirt,Dress. Max product in each category is 2", "", false, "Newcomer Trial", 4, 200.0, 1 },
                    { 2, 30, "Customers will feel comfortable and appreciate the size and quality of the outfit, The package will provide 8 products in 5 packages:Shirt,Short,Skirt,Dress,Accessories.  Max product in each category is 3", "", false, "Basic Package", 8, 600.0, 1 },
                    { 3, 30, "Customers will feel comfortable and appreciate the size and quality of the outfit, The package will provide 12 products in 6 packages:Shirt,Short,Skirt,Dress,Accessories,Costumes .Max product in each category is 4", "", false, "VIP Package", 12, 800.0, 1 },
                    { 4, 30, "excited to introduce the package, designed to make this summer unforgettable for couples and close friends! Celebrate the warmth of the season and the bonds of love with our exclusive matching items that perfectly capture the essence of togetherness", "", false, "'Love'Summer", 4, 600.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Partner" }
                });

            migrationBuilder.InsertData(
                table: "CategoryPackages",
                columns: new[] { "Id", "CategoryId", "MaxAvailableQuantity", "PackageId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 1 },
                    { 2, 2, 2, 1, 1 },
                    { 3, 3, 2, 1, 1 },
                    { 4, 4, 2, 1, 1 },
                    { 5, 1, 3, 2, 1 },
                    { 6, 2, 3, 2, 1 },
                    { 7, 3, 3, 2, 1 },
                    { 8, 4, 3, 2, 1 },
                    { 9, 6, 3, 2, 1 },
                    { 10, 1, 4, 3, 1 },
                    { 11, 2, 4, 3, 1 },
                    { 12, 3, 4, 3, 1 },
                    { 13, 4, 4, 3, 1 },
                    { 14, 6, 4, 3, 1 },
                    { 15, 7, 4, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "AmountMoney", "CustomerId", "Date", "Type" },
                values: new object[] { 1, 20.0, 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8923), "Khuyen Mai" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Address", "AreaId", "Email", "Name", "OTP", "Password", "Phone", "Status", "X", "Y" },
                values: new object[,]
                {
                    { 1, "https://www.grab.com/vn/express/", 1, "Grap@gmail.com", "Grap", "", "", "123456", 0, "10.8447022", "106.7618557" },
                    { 2, "https://be.com.vn/", 1, "Grap@gmail.com", "Bee", "", "", "123456", 0, "10.8447022", "106.7618557" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "AvailableQuantity", "Deposit", "Description", "IdBrand", "IdCategory", "IsFeatured", "IsUsed", "Name", "Price", "Quantity", "Size", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 20, 0.10000000000000001, "Men's and Women's Short Sleeve Shirt Loose Letter Couple Ins Shirt Multifunctional Vintage Half Sleeve UFO Shirt", 1, 1, false, "False", "Cosmic Planet", 100f, 20, "M", 1, "New" },
                    { 2, 20, 0.10000000000000001, "The ZHUXIA loose-fitting, short-sleeved shirt with a retro Japanese vintage style is a great choice for women's summer fashion.", 2, 1, false, "False", "ZHUXIA-Shirt", 110f, 20, "X", 1, "New" },
                    { 3, 20, 0.14999999999999999, "Men's basic wide-leg khaki pants made in Korea are extremely beautiful, 3-color elastic waist pants show off Korean style", 3, 2, false, "False", "Men's basic wide-leg pants", 160f, 20, "X", 1, "New" },
                    { 4, 20, 0.14999999999999999, "[HOT MODEL 2023] made of cool linen fabric, high-waisted with elastic waistband and drawstring for adjustable fit.", 3, 1, false, "False", "Wide-leg women's pants", 150f, 20, "M", 1, "New" },
                    { 5, 20, 0.10000000000000001, "Gonz BLACK Loose FORM T-SHIRT - GONZ The Face 4 NEW HOT 2024", 3, 1, false, "False", "Gonz WIDE FORM T-SHIRT", 130f, 20, "M", 1, "New" },
                    { 6, 20, 0.20000000000000001, "This vintage floral dress features a flattering A-line silhouette with a delicate floral print. Perfect for a summer day out or a casual evening event.", 1, 1, false, "False", "Vintage Floral Dress", 200f, 20, "M", 1, "New" },
                    { 7, 0, 0.14999999999999999, "Make a statement with this stunning floral maxi skirt. Its flowing design and beautiful floral pattern will turn heads wherever you go.", 3, 4, false, "False", "Floral Maxi Skirt", 170f, 0, "XS", 1, "New" },
                    { 8, 0, 0.20000000000000001, "Men's and women's couple shirts with a dog and cat pulling a leash design", 3, 7, false, "False", "Dog cat couple", 230f, 0, "XS", 1, "New" },
                    { 9, 20, 0.20000000000000001, "Men's sports shirt absorbent and dries quickly", 2, 1, false, "FALSE", "Men's sports shirt", 200f, 20, "XL", 1, "New" },
                    { 10, 20, 0.0, "Fabric/material: Chemical fiber/Polyester (Polyester Fiber) Ingredient content: 100%", 3, 3, false, "FALSE", "Women's low waist A-line dress", 120f, 20, "S", 1, "New" },
                    { 11, 20, 0.0, "Cool t-shirt with wide FORM sleeves and embroidered chest", 1, 1, false, "FALSE", "T-shirt with embroidered bow tie and cool elastic sleeves, loose-sleeved form", 100f, 20, "M", 1, "New" },
                    { 12, 20, 0.0, "The fabric is beautiful, not fuzzy, not shrinkable, soft and thick, absorbs sweat extremely quickly, and is super cool to wear.", 1, 1, false, "FALSE", "BEARLESS Unisex T-shirt", 100f, 20, "L", 1, "New" },
                    { 13, 20, 0.0, "Style: Casual Travel/Simple Popular elements / Craftsmanship: Ruffles", 3, 3, false, "FALSE", "Bohemian irregular wavy lace skirt", 100f, 20, "M", 1, "New" },
                    { 14, 20, 0.0, "White Lolita Dress with Flared Flared Lace and Elastic Waist for Women", 3, 3, false, "FALSE", "White Lolita Dress with Lace Flare", 100f, 20, "M", 1, "New" },
                    { 15, 20, 0.0, "The material is light, soft and super cool to wear. The design is youthful, cute, feminine with many beautiful patterns", 5, 5, false, "FALSE", "Áo bà ba cổ tròn vạt đứng lụa siêu cao cấp (Traditional of VN)", 100f, 20, "L", 1, "New" },
                    { 16, 20, 0.0, "High quality brocade silk ao dai, super pretty stylized sleeves", 5, 5, false, "FALSE", "Áo bà ba lụa gấm tơ cao cấp  (Traditional of VN)", 120f, 20, "L", 1, "New" },
                    { 17, 20, 0.0, "Fans of Thai movies cannot miss this uniform", 5, 5, false, "FALSE", "Thai School Uniform Men's Version", 150f, 20, "XL", 1, "New" },
                    { 18, 20, 0.0, "Style: Sweet and fresh / College", 5, 5, false, "FALSE", "Blue Japanese Female School Uniform", 150f, 20, "M", 1, "New" },
                    { 19, 20, 0.0, "Popular elements: Flowers Quantity: 1 headscarf + 1 sunglasses", 6, 6, false, "FALSE", "Idylls Women's Turban", 80f, 20, "X", 1, "New" },
                    { 20, 20, 0.0, "Square twisted wire of all sizes, machine cut, 45cm and 50cm thick", 6, 6, false, "FALSE", "Accessories Square twisted necklaces of all sizes 3mm, 4mm, 5mm, 6mm, 8mm, 10mm", 900f, 20, "M", 1, "New" },
                    { 21, 20, 0.0, "G-Shock with strong design and high durability, Edifice with modern design and many outstanding features, Sheen with classic and luxurious design.", 6, 6, false, "FALSE", "Casio 42.5 mm Men's Watch MTP-M100D-7AVDF", 1500f, 20, "M", 1, "New" },
                    { 22, 20, 0.0, "The main design trend of Citizen watches is simple and elegant.", 6, 6, false, "FALSE", "Citizen 28mm Women's Watch EM0809-83Z", 1500f, 20, "M", 1, "New" },
                    { 23, 20, 0.0, "Unisex glasses for both men and women Anti-ultraviolet rays, UV400 rays, maximum eye protection", 6, 6, false, "FALSE", "UV protection sunglasses from NICOLE Korea", 500f, 20, "XL", 1, "New" },
                    { 24, 20, 0.0, "Unique high-end beach travel couple outfit set for men and women for summer 2024", 7, 7, false, "FALSE", "Men's and women's couple's set of couple's clothes for traveling to the beach", 300f, 20, "XL", 1, "New" },
                    { 25, 20, 0.0, "D.r silk dress with fancy off-the-shoulder lantern form for women to wear to go out and travel to the beach", 7, 7, false, "FALSE", "Pink double set includes men's shirt, women's skirt and cardigan", 300f, 20, "M", 1, "New" },
                    { 26, 20, 0.0, "Short dress, Korean luxury Ulzzang babydoll dress Maxi", 4, 4, false, "FALSE", "Vintage Women's 2-shoulder bow-tie dress", 120f, 20, "M", 1, "New" },
                    { 27, 20, 0.0, "Fabric name: Corduroy, Elasticity: Microplastic", 2, 2, false, "FALSE", "Spring and Autumn Fashion Casual Wide Leg Corduroy Pants for Men", 100f, 20, "L", 1, "New" },
                    { 28, 20, 0.0, "Bigsize high-waist cargo pants model. Very beautiful straight shape. Easy to coordinate with different types of outfits: going out, going to work, going to parties... Loose, loose-fitting pants will bring you comfort and ease.", 2, 2, false, "FALSE", "Women's high-waisted wide-leg sports pants with vertical striped pattern, sporty fashion style", 100f, 20, "M", 1, "New" },
                    { 29, 20, 0.0, "Thai crocodile t-shirt with 4-way stretch as uniform for employees with instant decal printing", 5, 5, false, "FALSE", "Polo Uniform T-shirt made of 4-way crocodile material", 100f, 20, "M", 1, "New" },
                    { 30, 20, 0.0, "Fabric name: polyester. Main fabric component: polyester", 5, 5, false, "FALSE", "Short-sleeved hotel uniform, waiter, restaurant work uniform", 100f, 20, "S", 1, "New" },
                    { 31, 20, 0.0, "Full rim glasses. Fashion style", 6, 6, false, "FALSE", "Korean retro style Small Square Frame Sunglasses", 200f, 20, "M", 1, "New" },
                    { 32, 20, 0.0, "100% brand new, high quality", 6, 6, false, "FALSE", "Retro fashion cat eye sunglasses for women", 150f, 20, "M", 1, "New" },
                    { 33, 20, 0.0, "100% brand new, high quality", 6, 6, false, "FALSE", "JENNIE sunglasses with Y2K style", 300f, 20, "M", 1, "New" },
                    { 34, 20, 0.0, "Couple shirt dresses/matching outfits for men and women.", 7, 7, false, "FALSE", "Cute men's and women's couple's clothes", 200f, 20, "M", 1, "New" },
                    { 35, 20, 0.0, "Latest models of men's and women's couple clothes, used for wedding photography, going out, and traveling, very youthful and stylish!", 7, 7, false, "FALSE", "New model men's and women's couple clothes", 200f, 20, "L", 1, "New" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Phone", "RoleId", "Status" },
                values: new object[,]
                {
                    { 1, "admin", "123456", "123456789", 1, 1 },
                    { 2, "leecois@gmail.com", "123456", "12345678", 1, 1 },
                    { 3, "Grap@gmail.com", "123456", "", 2, 1 },
                    { 4, "Bee@gmail.com", "123456", "", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CustomerId", "OTP", "Status", "WalletCode", "WalletName", "WalletPassword" },
                values: new object[] { 1, 1, 0L, 1, "123", "Momo", "123" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ID", "IdProduct", "Link" },
                values: new object[,]
                {
                    { 1, 1, "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lvmx2enml619c4" },
                    { 2, 1, "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lvmx2hoo6zzv29" },
                    { 3, 8, "https://down-vn.img.susercontent.com/file/1e890d0f6604feb16d1c020fb4296a56" },
                    { 4, 8, "https://down-vn.img.susercontent.com/file/a73d437dcb06544be1efcb2fff22154d" },
                    { 5, 2, "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lk7tiyi2rj4t2c" },
                    { 6, 2, "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lk7tiyi2rj0481" },
                    { 7, 3, "https://down-vn.img.susercontent.com/file/eaecde77548a04719b5822daf9b5e4b7" },
                    { 8, 3, "https://down-vn.img.susercontent.com/file/216545f44c9824c6548349fbb63d9103" },
                    { 9, 4, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwoaor9y31sr34" },
                    { 10, 4, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwoaor9ooj4p98" },
                    { 11, 5, "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lt4vm66wzc73f1" },
                    { 12, 5, "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lt4vm8t95aet8f" },
                    { 13, 6, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwle0pi76c4b5f" },
                    { 14, 6, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lstn66047vt094" },
                    { 15, 6, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lstn6604aoxw93" },
                    { 16, 7, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd6m-lvcplff2w8bx42" },
                    { 17, 7, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd49-lvcpl96w0b3v79" },
                    { 18, 7, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd4d-lvcplok5iobc5f" },
                    { 19, 9, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd46-lvwmevojczsfbe" },
                    { 20, 10, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwjun5k781y12e" },
                    { 21, 11, "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lhsgugwdqg7991" },
                    { 22, 12, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd5a-lv49t9zt96ekd7" },
                    { 23, 13, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lvfjui2cg87hd0" },
                    { 24, 14, "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lp66e2bf9opnd0" },
                    { 25, 15, "https://down-vn.img.susercontent.com/file/166a8d410782cede0c9aab49f2ddfbb5" },
                    { 26, 16, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-luuu44mmw1zm38" },
                    { 27, 17, "https://down-vn.img.susercontent.com/file/sg-11134201-7rcem-lsz1l11wdxtrd6" },
                    { 28, 18, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd4z-lu0ei4d8jihjf3" },
                    { 29, 19, "https://down-vn.img.susercontent.com/file/sg-11134201-7rd6s-lvmvkwgtbyx80a" },
                    { 30, 20, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lubowd6lh1xtd3" },
                    { 31, 21, "https://www.thegioididong.com/dong-ho-deo-tay/casio-mtp-m100d-7avdf-nam#top-color-images-gallery-1174" },
                    { 32, 22, "https://www.thegioididong.com/dong-ho-deo-tay/citizen-em0809-83z-nu#top-color-images-gallery-15" },
                    { 33, 23, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwifcpy87x099f" },
                    { 34, 24, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lv6d50ieiv167f" },
                    { 35, 25, "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lgl8he41htnu33" },
                    { 36, 26, "https://down-vn.img.susercontent.com/file/cn-11134207-7r98o-lp4ymq73hkkcf0" },
                    { 37, 27, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lw2susc23ye1af" },
                    { 38, 28, "https://down-vn.img.susercontent.com/file/sg-11134201-22120-ap2882tdo4kv7c" },
                    { 39, 29, "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lgoo5rn93r6k17" },
                    { 40, 30, "https://down-vn.img.susercontent.com/file/cn-11134301-7qukw-ljqq0pro1hisbc" },
                    { 41, 31, "https://down-vn.img.susercontent.com/file/sg-11134201-7rcd3-lrtwdc5pxtvgce" },
                    { 42, 32, "https://down-vn.img.susercontent.com/file/sg-11134201-7rccd-ls6ht57qzywrfc" },
                    { 43, 33, "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lgngo6qyhohee1" },
                    { 44, 34, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmmrmhaq9e5baa" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "DateTransaction", "DepositId", "Paymethod", "Status", "WalletId" },
                values: new object[] { 1, 0.0, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8886), 1, "", 0, 1 });

            migrationBuilder.InsertData(
                table: "CustomerPackage",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "DateFrom", "DateTo", "IsReturnedDeposit", "PackageId", "PackageName", "Price", "QuantityOfItems", "ReceiverAddress", "ReceiverName", "ReceiverPhone", "ReturnDeposit", "Status", "TotalDeposit", "TransactionId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 7, 15, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8850), new DateTime(2024, 8, 14, 21, 3, 11, 277, DateTimeKind.Local).AddTicks(8851), false, 1, "Newcomer Trial", 200.0, null, "Nha Van Hoa Sinh Vien", "Khanh Sky", "0325739910", 0.0, 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPackages_CategoryId",
                table: "CategoryPackages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPackages_PackageId",
                table: "CategoryPackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_CustomerId",
                table: "CustomerPackage",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_PackageId",
                table: "CustomerPackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_TransactionId",
                table: "CustomerPackage",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_CustomerId",
                table: "Deposits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_CustomerId",
                table: "FavouriteProduct",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_ProductId",
                table: "FavouriteProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdProduct",
                table: "Image",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInUserPackages_ProductId",
                table: "ItemInUserPackages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInUserPackages_UserPackageId",
                table: "ItemInUserPackages",
                column: "UserPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_AreaId",
                table: "Partners",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdBrand",
                table: "Product",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReturnOrders_ProductId",
                table: "ProductReturnOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReturnOrders_ReturnOrderId",
                table: "ProductReturnOrders",
                column: "ReturnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_CustomerId",
                table: "ReturnOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_CustomerPackageId",
                table: "ReturnOrders",
                column: "CustomerPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_PartnerId",
                table: "ReturnOrders",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewImages_ReviewId",
                table: "ReviewImages",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DepositId",
                table: "Transactions",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPackages");

            migrationBuilder.DropTable(
                name: "FavouriteProduct");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ItemInUserPackages");

            migrationBuilder.DropTable(
                name: "ProductReturnOrders");

            migrationBuilder.DropTable(
                name: "ReviewImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ReturnOrders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CustomerPackage");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
