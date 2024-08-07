﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Org.BouncyCastle.Utilities;
using SWD392.OutfitBox.DataLayer.Entities;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Net.WebRequestMethods;

namespace SWD392.OutfitBox.DataLayer.Databases.Redis
{
    public static class ContextDataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    ID = 1,
                    Name = "NOSBYN",
                    Description = " Explosive within the Vietnamese fashion community in 2013, Nosbyn captured the hearts of young fashion enthusiasts with its stylish yet basic items. Leading the way were its signature solid-colored crop tops, which remained a prominent fixture even after three years of development. Today, Nosbyn continues to hold a strong position in the hearts of Vietnamese fashionistas.",
                    ImageUrl = "https://theme.hstatic.net/200000571545/1000929382/14/logo.png?v=171",
                    Status = 1
                },
                new Brand
                {
                    ID = 2,
                    Name = "THE BLUE T-SHIRT",
                    Description = "The BlueTshirt, established in 2012, initially introduced simple t-shirt designs with inspiring slogans to the Vietnamese market. The brand's designs strike a perfect balance between elegance and a free-spirited nature, reflecting the personality of its founder. Whether you are a gentle and graceful woman or someone with a strong individualistic style, The BlueTshirt offers a wide range of products to cater to your preferences.",
                    ImageUrl = "https://theme.hstatic.net/1000053720/1001049163/14/logo.png?v=3942",
                    Status = 1
                },
                new Brand
                {
                    ID = 3,
                    Name = "OUTFIT4RENT",
                    Description = "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style",
                    ImageUrl = "https://panel.outfit4rent.online/images/logo-mark-light.svg",
                    Status = 1
                }
                ,
                new Brand
                {
                    ID = 4,
                    Name = "JUNO",
                    Description = "With an unwavering commitment to quality craftsmanship, ethical practices, and timeless design, O4R is poised to become the go-to destination for fashion-conscious individuals seeking both substance and style",
                    ImageUrl = "https://file.hstatic.net/1000003969/file/logo-svg.svg",
                    Status = 1
                },
                new Brand
                {
                    ID = 5,
                    Name = "Uniqlo",
                    Description = "Uniqlo LLC is a Japanese casual wear design, apparel, and retail company.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/92/UNIQLO_logo.svg",
                    Status = 1
                },
                new Brand
                {
                    ID = 6,
                    Name = "Zara",
                    Description = "Zara is a Spanish clothing and accessories brand.",
                    ImageUrl = "https://img.salehere.co.th/p/1200x0/2024/02/16/gdlpd8hwxiob.jpg",
                    Status = 1
                },
                new Brand
                {
                    ID = 7,
                    Name = "Pull&Bear",
                    Description = "Famous Spanish fashion brand Pull&Bear.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgJ2G23IAT9jiabKjH8VZ09gtj9BRXH2kCsA&s",
                    Status = 1
                }
        );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name = "Shirt",
                    Description = "T-Shirt,Vest,Polo,Smock,...",
                    ImageUrl = "https://hoangnguyenstore.com/wp-content/uploads/2021/11/ao-so-mi-dior-hoa-tiet-nhen-asmd01-5.webp"
                },
                new Category
                {
                    ID = 2,
                    Name = "Short",
                    Description = "Gauchos,Jeans,Trousers,...",
                    ImageUrl = "https://cf.shopee.vn/file/53ba7e3dcff647db1ff302f6c378a0bc"
                },
                new Category
                {
                    ID = 3,
                    Name = "Skirt",
                    Description = "Skater,Circle,Aline,Maxi,Sarong,...",
                    ImageUrl = "https://lzd-img-global.slatic.net/g/p/ff217e1a9b75a39108b8a04c22d164dc.jpg_720x720q80.jpg"
                },
                new Category
                {
                    ID = 4,
                    Name = "Dress",
                    Description = "A-line,Empire,Tent,Princess,Shift,...",
                    ImageUrl= "https://image.dhgate.com/0x0s/f2-albu-g17-M00-71-84-rBVa4V_J8_iAXsmWAADRlVU_URo051.jpg/2021-black-ball-gown-gothic-wedding-dresses.jpg"
                },
                new Category
                {
                    ID = 5,
                    Name = "Costumes",
                    Description = "Ao dai,Traditional clothers,...",
                    ImageUrl= "https://i.pinimg.com/originals/47/2c/21/472c21c67c84e2d69866319ccf7906d6.jpg"
                },
                new Category
                {
                    ID = 6,
                    Name = "Accessories",
                    Description = "Sunglasses,Tie,Watch,Bow,...",
                    ImageUrl = "https://d2hg8ctx8thzji.cloudfront.net/clusterfeed.net/wp-content/uploads/2020/07/6CommonlyUsedAccessoriestoChooseFrom-750x532.jpg"

                },
                 new Category
                 {
                     ID= 7,
                     Name= "Couple",
                     Description = "Way for couples or friends to express their affection and bond with each other",
                     ImageUrl= "https://top.chon.vn/wp-content/uploads/2019/09/shop-do-doi-5.jpg"
                 }
                );
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ID = 1,
                 Name = "Cosmic Planet",
                 Price = 100,
                 Size = "M",
                 //    Color = "Blue",
                 Description = "Men's and Women's Short Sleeve Shirt Loose Letter Couple Ins Shirt Multifunctional Vintage Half Sleeve UFO Shirt",
                 Status = 1,
                 IsUsed = "False",
                 Deposit = 0.1,
                 IdCategory = 1,
                 Quantity = 20,
                 IdBrand = 1,
                 AvailableQuantity = 20,
                 Type = "New",
             },
            new Product
            {
                ID = 2,
                Name = "ZHUXIA-Shirt",
                Price = 110,
                Size = "X",
                //   Color = "Grey",
                Description = "The ZHUXIA loose-fitting, short-sleeved shirt with a retro Japanese vintage style is a great choice for women's summer fashion.",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.1,
                IdCategory = 1,
                Quantity = 20,
                IdBrand = 2,
                AvailableQuantity = 20,
                Type = "New"
            },
            new Product
            {
                ID = 3,
                Name = "Men's basic wide-leg pants",
                Price = 160,
                Size = "X",
                //  Color = "Black",
                Description = "Men's basic wide-leg khaki pants made in Korea are extremely beautiful, 3-color elastic waist pants show off Korean style",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.15,
                IdCategory = 2,
                Quantity = 20,
                IdBrand = 3,
                AvailableQuantity = 20,
                Type = "New"
            },
            new Product
            {
                ID = 4,
                Name = "Wide-leg women's pants",
                Price = 150,
                Size = "M",
                //   Color = "White",
                Description = "[HOT MODEL 2023] made of cool linen fabric, high-waisted with elastic waistband and drawstring for adjustable fit.",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.15,
                IdCategory = 1,
                Quantity = 20,
                IdBrand = 3,
                AvailableQuantity = 20,
                Type = "New"
            },
            new Product
            {
                ID = 5,
                Name = "Gonz WIDE FORM T-SHIRT",
                Price = 130,
                Size = "M",
                // Color = "Black",
                Description = "Gonz BLACK Loose FORM T-SHIRT - GONZ The Face 4 NEW HOT 2024",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.1,
                IdCategory = 1,
                Quantity = 20,
                IdBrand = 3,
                AvailableQuantity = 20,
                Type = "New"
            },
            new Product
            {
                ID = 6,
                Name = "Vintage Floral Dress",
                Price = 200,
                Size = "M",
                //    Color = "Pink",
                Description = "This vintage floral dress features a flattering A-line silhouette with a delicate floral print. Perfect for a summer day out or a casual evening event.",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.2,
                IdCategory = 1,
                Quantity = 20,
                IdBrand = 1,
                AvailableQuantity = 20,
                Type = "New"
            },
            new Product
            {
                ID = 7,
                Name = "Floral Maxi Skirt",
                Price = 170,
                Size = "XS",
                //  Color = "White",
                Description = "Make a statement with this stunning floral maxi skirt. Its flowing design and beautiful floral pattern will turn heads wherever you go.",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.15,
                IdCategory = 4,
                IdBrand = 3,
                Type = "New"
            },
            new Product
            {
                ID = 8,
                Name = "Dog cat couple",
                Price = 230,
                Size = "XS",
                Description = "Men's and women's couple shirts with a dog and cat pulling a leash design",
                Status = 1,
                IsUsed = "False",
                Deposit = 0.2,
                IdCategory = 7,
                IdBrand = 3,
                Type = "New"
            },
                new Product { ID = 9, Name = "Men's sports shirt", Price = 200, Size = "XL", Description = "Men's sports shirt absorbent and dries quickly", Status = 1, IsUsed = "FALSE", Deposit = 0.2, IdCategory = 1, Quantity = 20, AvailableQuantity = 20, IdBrand = 2, Type = "New" },
                new Product { ID = 10, Name = "Women's low waist A-line dress", Price = 120, Size = "S", Description = "Fabric/material: Chemical fiber/Polyester (Polyester Fiber) Ingredient content: 100%", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 3, Quantity = 20, AvailableQuantity = 20, IdBrand = 3, Type = "New" },
                new Product { ID = 11, Name = "T-shirt with embroidered bow tie and cool elastic sleeves, loose-sleeved form", Price = 100, Size = "M", Description = "Cool t-shirt with wide FORM sleeves and embroidered chest", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 1, Quantity = 20, AvailableQuantity = 20, IdBrand = 1, Type = "New" },
                new Product { ID = 12, Name = "BEARLESS Unisex T-shirt", Price = 100, Size = "L", Description = "The fabric is beautiful, not fuzzy, not shrinkable, soft and thick, absorbs sweat extremely quickly, and is super cool to wear.", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 1, Quantity = 20, AvailableQuantity = 20, IdBrand = 1, Type = "New" },
                new Product { ID = 13, Name = "Bohemian irregular wavy lace skirt", Price = 100, Size = "M", Description = "Style: Casual Travel/Simple Popular elements / Craftsmanship: Ruffles", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 3, Quantity = 20, AvailableQuantity = 20, IdBrand = 3, Type = "New" },
                new Product { ID = 14, Name = "White Lolita Dress with Lace Flare", Price = 100, Size = "M", Description = "White Lolita Dress with Flared Flared Lace and Elastic Waist for Women", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 3, Quantity = 20, AvailableQuantity = 20, IdBrand = 3, Type = "New" },
                new Product { ID = 15, Name = "Áo bà ba cổ tròn vạt đứng lụa siêu cao cấp (Traditional of VN)", Price = 100, Size = "L", Description = "The material is light, soft and super cool to wear. The design is youthful, cute, feminine with many beautiful patterns", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 16, Name = "Áo bà ba lụa gấm tơ cao cấp  (Traditional of VN)", Price = 120, Size = "L", Description = "High quality brocade silk ao dai, super pretty stylized sleeves", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 17, Name = "Thai School Uniform Men's Version", Price = 150, Size = "XL", Description = "Fans of Thai movies cannot miss this uniform", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 18, Name = "Blue Japanese Female School Uniform", Price = 150, Size = "M", Description = "Style: Sweet and fresh / College", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 19, Name = "Idylls Women's Turban", Price = 80, Size = "X", Description = "Popular elements: Flowers Quantity: 1 headscarf + 1 sunglasses", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 20, Name = "Accessories Square twisted necklaces of all sizes 3mm, 4mm, 5mm, 6mm, 8mm, 10mm", Price = 900, Size = "M", Description = "Square twisted wire of all sizes, machine cut, 45cm and 50cm thick", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 21, Name = "Casio 42.5 mm Men's Watch MTP-M100D-7AVDF", Price = 1500, Size = "M", Description = "G-Shock with strong design and high durability, Edifice with modern design and many outstanding features, Sheen with classic and luxurious design.", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 22, Name = "Citizen 28mm Women's Watch EM0809-83Z", Price = 1500, Size = "M", Description = "The main design trend of Citizen watches is simple and elegant.", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 23, Name = "UV protection sunglasses from NICOLE Korea", Price = 500, Size = "XL", Description = "Unisex glasses for both men and women Anti-ultraviolet rays, UV400 rays, maximum eye protection", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 24, Name = "Men's and women's couple's set of couple's clothes for traveling to the beach", Price = 300, Size = "XL", Description = "Unique high-end beach travel couple outfit set for men and women for summer 2024", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 7, Quantity = 20, AvailableQuantity = 20, IdBrand = 7, Type = "New" },
                new Product { ID = 25, Name = "Pink double set includes men's shirt, women's skirt and cardigan", Price = 300, Size = "M", Description = "D.r silk dress with fancy off-the-shoulder lantern form for women to wear to go out and travel to the beach", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 7, Quantity = 20, AvailableQuantity = 20, IdBrand = 7, Type = "New" },
                new Product { ID = 26, Name = "Vintage Women's 2-shoulder bow-tie dress", Price = 120, Size = "M", Description = "Short dress, Korean luxury Ulzzang babydoll dress Maxi", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 4, Quantity = 20, AvailableQuantity = 20, IdBrand = 4, Type = "New" },
                new Product { ID = 27, Name = "Spring and Autumn Fashion Casual Wide Leg Corduroy Pants for Men", Price = 100, Size = "L", Description = "Fabric name: Corduroy, Elasticity: Microplastic", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 2, Quantity = 20, AvailableQuantity = 20, IdBrand = 2, Type = "New" },
                new Product { ID = 28, Name = "Women's high-waisted wide-leg sports pants with vertical striped pattern, sporty fashion style", Price = 100, Size = "M", Description = "Bigsize high-waist cargo pants model. Very beautiful straight shape. Easy to coordinate with different types of outfits: going out, going to work, going to parties... Loose, loose-fitting pants will bring you comfort and ease.", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 2, Quantity = 20, AvailableQuantity = 20, IdBrand = 2, Type = "New" },
                new Product { ID = 29, Name = "Polo Uniform T-shirt made of 4-way crocodile material", Price = 100, Size = "M", Description = "Thai crocodile t-shirt with 4-way stretch as uniform for employees with instant decal printing", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 30, Name = "Short-sleeved hotel uniform, waiter, restaurant work uniform", Price = 100, Size = "S", Description = "Fabric name: polyester. Main fabric component: polyester", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 5, Quantity = 20, AvailableQuantity = 20, IdBrand = 5, Type = "New" },
                new Product { ID = 31, Name = "Korean retro style Small Square Frame Sunglasses", Price = 200, Size = "M", Description = "Full rim glasses. Fashion style", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 32, Name = "Retro fashion cat eye sunglasses for women", Price = 150, Size = "M", Description = "100% brand new, high quality", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 33, Name = "JENNIE sunglasses with Y2K style", Price = 300, Size = "M", Description = "100% brand new, high quality", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 6, Quantity = 20, AvailableQuantity = 20, IdBrand = 6, Type = "New" },
                new Product { ID = 34, Name = "Cute men's and women's couple's clothes", Price = 200, Size = "M", Description = "Couple shirt dresses/matching outfits for men and women.", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 7, Quantity = 20, AvailableQuantity = 20, IdBrand = 7, Type = "New" },
                new Product { ID = 35, Name = "New model men's and women's couple clothes", Price = 200, Size = "L", Description = "Latest models of men's and women's couple clothes, used for wedding photography, going out, and traveling, very youthful and stylish!", Status = 1, IsUsed = "FALSE", Deposit = 0, IdCategory = 7, Quantity = 20, AvailableQuantity = 20, IdBrand = 7, Type = "New" });
            modelBuilder.Entity<Package>().HasData(
               new Package
               {
                   Id = 1,
                   Name = "Newcomer Trial",
                   Price = 200,
                   Description = "The new customer can use to experience, with total 4 product in 4 category: Shirt,Short,Skirt,Dress. Max product in each category is 2",
                   AvailableRentDays = 30,
                   Status = 1,
                   NumOfProduct = 4,
               },
               new Package
               {
                   Id = 2,
                   Name = "Basic Package",
                   Price = 600,
                   Description = "Customers will feel comfortable and appreciate the size and quality of the outfit, The package will provide 8 products in 5 packages:Shirt,Short,Skirt,Dress,Accessories.  Max product in each category is 3",
                   AvailableRentDays = 30,
                   Status = 1,
                   NumOfProduct = 8,

               },

               new Package
               {
                   Id = 3,
                   Name = "VIP Package",
                   Price = 800,
                   Description = "Customers will feel comfortable and appreciate the size and quality of the outfit, The package will provide 12 products in 6 packages:Shirt,Short,Skirt,Dress,Accessories,Costumes .Max product in each category is 4",
                   AvailableRentDays = 30,
                   Status = 1,
                   NumOfProduct = 12,
               },
               new Package
               {
                   Id = 4,
                   Name = "'Love'Summer",
                   Price = 600,
                   Description = "excited to introduce the package, designed to make this summer unforgettable for couples and close friends! Celebrate the warmth of the season and the bonds of love with our exclusive matching items that perfectly capture the essence of togetherness",
                   AvailableRentDays = 30,
                   Status = 1,
                   NumOfProduct = 4,

               }
              );
            modelBuilder.Entity<CategoryPackage>().HasData(

                      new CategoryPackage
                      {
                          Id = 5,
                          CategoryId = 1,
                          PackageId = 2,
                          Status = 1,
                          MaxAvailableQuantity = 3,
                      },
                      new CategoryPackage
                      {
                          Id = 6,
                          CategoryId = 2,
                          PackageId = 2,
                          Status = 1,
                          MaxAvailableQuantity = 3,
                      },
                      new CategoryPackage
                      {
                          Id = 7,
                          CategoryId = 3,
                          PackageId = 2,
                          Status = 1,
                          MaxAvailableQuantity = 3,
                      },
                      new CategoryPackage
                      {
                          Id = 8,
                          CategoryId = 4,
                          PackageId = 2,
                          Status = 1,
                          MaxAvailableQuantity = 3
                      },
                      new CategoryPackage
                      {
                          Id = 9,
                          CategoryId = 6,
                          PackageId = 2,
                          Status = 1,
                          MaxAvailableQuantity = 3
                      }, new CategoryPackage
                      {
                          Id = 1,
                          CategoryId = 1,
                          PackageId = 1,
                          Status = 1,
                          MaxAvailableQuantity = 2,
                      },
                      new CategoryPackage
                      {
                          Id = 2,
                          CategoryId = 2,
                          PackageId = 1,
                          Status = 1,
                          MaxAvailableQuantity = 2,
                      },
                      new CategoryPackage
                      {
                          Id = 3,
                          CategoryId = 3,
                          PackageId = 1,
                          Status = 1,
                          MaxAvailableQuantity = 2,
                      },
                        new CategoryPackage
                        {
                            Id = 4,
                            CategoryId = 4,
                            PackageId = 1,
                            Status = 1,
                            MaxAvailableQuantity = 2
                        }, new CategoryPackage
                        {
                            Id = 10,
                            CategoryId = 1,
                            PackageId = 3,
                            Status = 1,
                            MaxAvailableQuantity = 4,
                        },
                      new CategoryPackage
                      {
                          Id = 11,
                          CategoryId = 2,
                          PackageId = 3,
                          Status = 1,
                          MaxAvailableQuantity = 4,
                      },
                      new CategoryPackage
                      {
                          Id = 12,
                          CategoryId = 3,
                          PackageId = 3,
                          Status = 1,
                          MaxAvailableQuantity = 4,
                      },
                      new CategoryPackage
                      {
                          Id = 13,
                          CategoryId = 4,
                          PackageId = 3,
                          Status = 1,
                          MaxAvailableQuantity = 4
                      },
                      new CategoryPackage
                      {
                          Id = 14,
                          CategoryId = 6,
                          PackageId = 3,
                          Status = 1,
                          MaxAvailableQuantity = 4
                      }
                      ,
                      new CategoryPackage
                      {
                          Id = 15,
                          CategoryId = 7,
                          PackageId = 4,
                          Status = 1,
                          MaxAvailableQuantity = 4
                      }
            );
            modelBuilder.Entity<Image>().HasData(
                 new Image
                 {
                     ID = 1,
                     Link = "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lvmx2enml619c4",
                     IdProduct = 1,
                 },
                  new Image
                  {
                      ID = 2,
                      Link = "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lvmx2hoo6zzv29",
                      IdProduct = 1,
                  },
                  new Image
                  {
                      ID= 3,
                      Link = "https://down-vn.img.susercontent.com/file/1e890d0f6604feb16d1c020fb4296a56",
                      IdProduct = 8,
                  },
                  new Image
                  {
                      ID = 4,
                      Link= "https://down-vn.img.susercontent.com/file/a73d437dcb06544be1efcb2fff22154d",
                      IdProduct = 8,
                  },
                  new Image
                  {
                       ID =5,
                       Link= "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lk7tiyi2rj4t2c",
                       IdProduct = 2,
                  },
                  new Image
                  {
                      ID = 6,
                      Link = "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lk7tiyi2rj0481",
                      IdProduct = 2
                  },
                  new Image
                  {
                      ID = 7,
                      Link = "https://down-vn.img.susercontent.com/file/eaecde77548a04719b5822daf9b5e4b7",
                      IdProduct = 3
                  },
                  new Image
                  {
                      ID=8,
                      Link = "https://down-vn.img.susercontent.com/file/216545f44c9824c6548349fbb63d9103",
                      IdProduct = 3
                  },
                  new Image
                  {
                      ID = 9,
                      Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwoaor9y31sr34",
                      IdProduct = 4
                  },
                  new Image
                  {
                      ID =10,
                      Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwoaor9ooj4p98",
                      IdProduct = 4
                  },
                  new Image
                  {
                      ID= 11,
                      Link= "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lt4vm66wzc73f1",
                      IdProduct = 5
                  },
                  new Image
                  {
                      ID= 12,
                      Link = "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lt4vm8t95aet8f",
                      IdProduct = 5
                  },
                  new Image
                  {
                      ID = 13,
                      Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwle0pi76c4b5f",
                      IdProduct = 6
                  },
                  new Image
                  {
                      ID=14,
                      Link= "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lstn66047vt094",
                      IdProduct = 6
                  },
                  new Image
                  {
                      ID = 15,
                      Link= "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lstn6604aoxw93",
                      IdProduct = 6
                  },
                  new Image
                  {
                      ID = 16,
                      Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd6m-lvcplff2w8bx42",
                      IdProduct = 7
                  },
                  new Image
                  {
                      ID= 17,
                      Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd49-lvcpl96w0b3v79",
                      IdProduct = 7
                  },
                  new Image
                  {
                      ID= 18,
                      Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd4d-lvcplok5iobc5f",
                      IdProduct = 7
                  },
                new Image { ID = 19, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd46-lvwmevojczsfbe", IdProduct = 9 },
                new Image { ID = 20, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwjun5k781y12e", IdProduct = 10 },
                new Image { ID = 21, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lhsgugwdqg7991", IdProduct = 11 },
                new Image { ID = 22, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd5a-lv49t9zt96ekd7", IdProduct = 12 },
                new Image { ID = 23, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lvfjui2cg87hd0", IdProduct = 13 },
                new Image { ID = 24, Link = "https://down-vn.img.susercontent.com/file/vn-11134201-7r98o-lp66e2bf9opnd0", IdProduct = 14 },
                new Image { ID = 25, Link = "https://down-vn.img.susercontent.com/file/166a8d410782cede0c9aab49f2ddfbb5", IdProduct = 15 },
                new Image { ID = 26, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-luuu44mmw1zm38", IdProduct = 16 },
                new Image { ID = 27, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rcem-lsz1l11wdxtrd6", IdProduct = 17 },
                new Image { ID = 28, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd4z-lu0ei4d8jihjf3", IdProduct = 18 },
                new Image { ID = 29, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rd6s-lvmvkwgtbyx80a", IdProduct = 19 },
                new Image { ID = 30, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lubowd6lh1xtd3", IdProduct = 20 },
                new Image { ID = 31, Link = "https://cdn.tgdd.vn/Products/Images/7264/313970/casio-mtp-m100d-7avdf-nam-2-1.jpg", IdProduct = 21 },
                new Image { ID = 32, Link = "https://cdn.tgdd.vn/Products/Images/7264/316403/citizen-em0809-83z-nu-1.jpg", IdProduct = 22 },
                new Image { ID = 33, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lwifcpy87x099f", IdProduct = 23 },
                new Image { ID = 34, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lv6d50ieiv167f", IdProduct = 24 },
                new Image { ID = 35, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lgl8he41htnu33", IdProduct = 25 },
                new Image { ID = 36, Link = "https://down-vn.img.susercontent.com/file/cn-11134207-7r98o-lp4ymq73hkkcf0", IdProduct = 26 },
                new Image { ID = 37, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lw2susc23ye1af", IdProduct = 27 },
                new Image { ID = 38, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-22120-ap2882tdo4kv7c", IdProduct = 28 },
                new Image { ID = 39, Link = "https://down-vn.img.susercontent.com/file/cn-11134207-7qukw-lgoo5rn93r6k17", IdProduct = 29 },
                new Image { ID = 40, Link = "https://down-vn.img.susercontent.com/file/cn-11134301-7qukw-ljqq0pro1hisbc", IdProduct = 30 },
                new Image { ID = 41, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rcd3-lrtwdc5pxtvgce", IdProduct = 31 },
                new Image { ID = 42, Link = "https://down-vn.img.susercontent.com/file/sg-11134201-7rccd-ls6ht57qzywrfc", IdProduct = 32 },
                new Image { ID = 43, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lgngo6qyhohee1", IdProduct = 33 },
                new Image { ID = 44, Link = "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmmrmhaq9e5baa", IdProduct = 34 }

                );
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = 1,
                        Name = "Khanh Sky",
                        Email = "Khanhvhdse173550@fpt.edu.vn",
                    
                        Phone = "0325739910",
                        Address = "Dong Nai",
                        Status = 1,
                        MoneyInWallet = 1000,
           
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "User2",
                        Email = "User2@gmail.com",
                     
                        Phone = "123",
                        Address = "HCM",
                        Status = 1,
                        MoneyInWallet = 100,
       
                    },
                    new Customer
                    {

                        Id = 3,
                        Name = "User3",
                        Email = "User3@gmail.com",
                     
                        Phone = "123",
                        Address = "HCM",
                        Status = 1,
                        MoneyInWallet = 100,
           
                    },
                    new Customer
                    {

                        Id = 4,
                        Name = "User4",
                        Email = "User4gmail.com",
                      
                        Phone = "123",
                        Address = "HCM",
                        Status = 1,
                        MoneyInWallet = 100,

                    }
                );
            modelBuilder.Entity<Area>().HasData(
                new Area
                {
                    Id = 1,
                    City = "Ho Chi Minh",
                    District = "Thu Duc",
                    Address = "Linh Trung",
                 
                },
                new Area
                {
                    Id = 2,
                    City = "Binh Duong",
                    District = "Di An",
                    Address = "Dong Hoa",
                   
                }
                );
            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    Id = 1,
                    Name = "Grap",
                    Address = "https://www.grab.com/vn/express/",
                    Phone = "123456",
                    Email = "Grap@gmail.com",
                    AreaId = 1,
                    X = "10.8447022",
                    Y = "106.7618557"
                },
                new Partner
                {
                    Id = 2,
                    Name = "Bee",
                    Address = "https://be.com.vn/",
                    Phone = "123456",
                    Email = "Grap@gmail.com",
                    AreaId = 1,
                    X = "10.8447022",
                    Y = "106.7618557"
                }
                );
            modelBuilder.Entity<CustomerPackage>().HasData(
                new CustomerPackage
                {
                    Id = 1,
                    CustomerId = 1,
                    PackageId = 1,
                    PackageName = "Newcomer Trial",
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(30),
                    Price = 200,
                    ReceiverName = "Khanh Sky",
                    ReceiverPhone = "0325739910",
                    ReceiverAddress = "Nha Van Hoa Sinh Vien",
                    Status = 1,
                    TransactionId = 1
                }
                ) ;
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    DateTransaction = DateTime.Now,
                    DepositId = 1,
                    WalletId = 1,
                }
                );
            modelBuilder.Entity<Wallet>().HasData(
                new Wallet
                {
                    Id= 1,
                    CustomerId=1,
                    Status = 1,
                    WalletName = "Momo",
                    WalletCode="123",
                    WalletPassword="123"
                }
                );
            modelBuilder.Entity<Deposit>().HasData(
                new Deposit
                {
                    Id =1,
                    CustomerId=1,
                    AmountMoney = 20,
                    Type = "Khuyen Mai",
                    Date = DateTime.Now,
                });
            modelBuilder.Entity<Role>().HasData(
                new Role{Id=1,Name = "Admin"},
                new Role { Id=2,Name ="Partner"}
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin", Password = "123456", Phone = "123456789", Status = 1, RoleId = 1 },
                new User { Id = 2, Email = "leecois@gmail.com", Password = "123456", Phone = "12345678", Status = 1, RoleId = 1 },
                new User { Id=3,Email="Grap@gmail.com",Password="123456",Status=1, RoleId = 2},
                new User { Id = 4, Email = "Bee@gmail.com", Password = "123456", Status = 1, RoleId = 2 }
                );
        }


    }
}
