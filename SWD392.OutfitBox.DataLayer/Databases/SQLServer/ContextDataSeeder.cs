using Microsoft.EntityFrameworkCore;
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
                }
        );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name = "Shirt",
                    Description = "T-Shirt,Vest,Polo,Smock,..."
                },
                new Category
                {
                    ID = 2,
                    Name = "Short",
                    Description = "Gauchos,Jeans,Trousers,..."
                },
                new Category
                {
                    ID = 3,
                    Name = "Skirt",
                    Description = "Skater,Circle,Aline,Maxi,Sarong,..."
                },
                new Category
                {
                    ID = 4,
                    Name = "Dress",
                    Description = "A-line,Empire,Tent,Princess,Shift,..."
                },
                new Category
                {
                    ID = 5,
                    Name = "Costumes",
                    Description = "Ao dai,Traditional clothers,..."
                },
                new Category
                {
                    ID = 6,
                    Name = "Accessories",
                    Description = "Sunglasses,Tie,Watch,Bow,..."
                },
                 new Category
                 {
                     ID= 7,
                     Name= "Couple",
                     Description = "Way for couples or friends to express their affection and bond with each other"
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
            }) ;
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
                  }
                  
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
        }


    }
}
