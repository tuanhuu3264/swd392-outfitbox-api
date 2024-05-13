﻿// <auto-generated />
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

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "",
                            Name = "Shirt"
                        },
                        new
                        {
                            ID = 2,
                            Description = "",
                            Name = "Short"
                        },
                        new
                        {
                            ID = 3,
                            Description = "",
                            Name = "Long-Skirt"
                        },
                        new
                        {
                            ID = 4,
                            Description = "",
                            Name = "Short-Skirt"
                        },
                        new
                        {
                            ID = 5,
                            Description = "",
                            Name = "Dress"
                        });
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

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("IsUsed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdType");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Type", b =>
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

                    b.HasKey("ID");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "",
                            Name = "New"
                        },
                        new
                        {
                            ID = 2,
                            Description = "",
                            Name = "IsUsed"
                        },
                        new
                        {
                            ID = 3,
                            Description = "",
                            Name = "Expected"
                        },
                        new
                        {
                            ID = 4,
                            Description = "",
                            Name = "Torn"
                        },
                        new
                        {
                            ID = 5,
                            Description = "",
                            Name = "Active"
                        },
                        new
                        {
                            ID = 6,
                            Description = "",
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Image", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SWD392.OutfitBox.Domain.Entities.Product", b =>
                {
                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD392.OutfitBox.Domain.Entities.Type", "Type")
                        .WithMany()
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
