﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWD392.OutfitBox.Infrastructure.Databases.SQLServer;

#nullable disable

namespace SWD392.OutfitBox.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distrinct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Bùng nổ trong cộng đồng giới trẻ yêu thích thời trang Việt Nam vào năm 2013 với những item basic nhưng vẫn cực kì thời trang, đi đầu là những chiếc áo croptop trơn đặc trưng, Nosbyn sau 3 năm phát triển vẫn luôn chiếm giữ giữ một vị trí vững chắc trong lòng mỗi tín đồ thời trang Việt. Phong cách tối giản trong kiểu dáng cùng những đường cut out sắc nét, gam màu pastel nhẹ nhàng thanh lịch là những chất liệu tạo nên một Nosbyn đầy tinh tế của ngày hôm nay. Hơn hết, song hành cùng chất lượng là giá thành vô cùng phải chăng mà thương hiệu này mang lại",
                            Link = "https://nosbyn.com/",
                            Name = "NOSBYN",
                            Status = 1
                        },
                        new
                        {
                            ID = 2,
                            Description = "Ra đời năm 2012, The BlueTshirt ban đầu mang đến thị trường Việt Nam các thiết kế áo thun đơn giản đi kèm những câu slogan đầy cảm hứng. Những thiết kế của The BlueTshirt là sự xen lẫn giữa nét thanh lịch và phóng khoáng, giữa sự nhẹ nhàng mà cá tính như chính người sáng lập ra nó. Dù là cô gái nhẹ nhàng yểu điệu hay cá tính, người ta vẫn có thể chọn cho mình một sản phẩm ưng ý ở The BlueTshirt.",
                            Link = "https://thebluetshirt.com/",
                            Name = "THE BLUE T-SHIRT",
                            Status = 1
                        });
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "",
                            Name = "Shirt",
                            Status = 0
                        },
                        new
                        {
                            ID = 2,
                            Description = "",
                            Name = "Short",
                            Status = 0
                        },
                        new
                        {
                            ID = 3,
                            Description = "",
                            Name = "Long-Skirt",
                            Status = 0
                        },
                        new
                        {
                            ID = 4,
                            Description = "",
                            Name = "Short-Skirt",
                            Status = 0
                        },
                        new
                        {
                            ID = 5,
                            Description = "",
                            Name = "Dress",
                            Status = 0
                        });
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.CategoryPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MaxAvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PackageId");

                    b.ToTable("CategoryPackages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MoneyInWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OTP")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.CustomerPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PackageId");

                    b.HasIndex("TransactionId");

                    b.ToTable("CustomerPackage");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AmountMoney")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.FavouriteProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavouriteProduct");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IdProduct");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ItemInUserPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateGive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReceive")
                        .HasColumnType("datetime2");

                    b.Property<double>("Deposit")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TornMoney")
                        .HasColumnType("float");

                    b.Property<int>("UserPackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserPackageId");

                    b.ToTable("ItemInUserPackages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableRentDays")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Deposit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("IsUsed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdCategory");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ProductReturnOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReturnOrderId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReturnOrderId");

                    b.ToTable("ProductReturnOrders");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ReturnOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReturn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PartnerId");

                    b.ToTable("ReturnOrders");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberStars")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ReviewImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("ReviewImages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<string>("Paymethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepositId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoldeId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<long>("OTP")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WalletCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.CategoryPackage", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Category", "Category")
                        .WithMany("categoryPackages")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Package", "Package")
                        .WithMany("CategoryPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.CustomerPackage", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "Customer")
                        .WithMany("UserPackages")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Package", "Package")
                        .WithMany("CustomerPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Transaction", "Transaction")
                        .WithMany("CustomerPackages")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Package");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Deposit", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.FavouriteProduct", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Image", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ItemInUserPackage", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.CustomerPackage", "UserPackage")
                        .WithMany("Items")
                        .HasForeignKey("UserPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("UserPackage");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Partner", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Area", "Area")
                        .WithMany("Partners")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Product", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ProductReturnOrder", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.ReturnOrder", "ReturnOrder")
                        .WithMany("ProductReturnOrders")
                        .HasForeignKey("ReturnOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ReturnOrder");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ReturnOrder", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "Customer")
                        .WithMany("ReturnOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Review", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ReviewImage", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Review", "Review")
                        .WithMany("ReviewImages")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Deposit", "Deposit")
                        .WithMany("Transactions")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.User", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Customer", "Customer")
                        .WithMany("Wallets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Area", b =>
                {
                    b.Navigation("Partners");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("categoryPackages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Customer", b =>
                {
                    b.Navigation("ReturnOrders");

                    b.Navigation("Reviews");

                    b.Navigation("UserPackages");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.CustomerPackage", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Deposit", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Package", b =>
                {
                    b.Navigation("CategoryPackages");

                    b.Navigation("CustomerPackages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.ReturnOrder", b =>
                {
                    b.Navigation("ProductReturnOrders");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Review", b =>
                {
                    b.Navigation("ReviewImages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Transaction", b =>
                {
                    b.Navigation("CustomerPackages");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
