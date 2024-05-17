using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Domain.Entities;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using ProductType = SWD392.OutfitBox.Domain.Entities.ProductType;

namespace FAMS.Core.Databases
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
                    Description = "Bùng nổ trong cộng đồng giới trẻ yêu thích thời trang Việt Nam vào năm 2013 với những item basic nhưng vẫn cực kì thời trang, đi đầu là những chiếc áo croptop trơn đặc trưng, Nosbyn sau 3 năm phát triển vẫn luôn chiếm giữ giữ một vị trí vững chắc trong lòng mỗi tín đồ thời trang Việt. Phong cách tối giản trong kiểu dáng cùng những đường cut out sắc nét, gam màu pastel nhẹ nhàng thanh lịch là những chất liệu tạo nên một Nosbyn đầy tinh tế của ngày hôm nay. Hơn hết, song hành cùng chất lượng là giá thành vô cùng phải chăng mà thương hiệu này mang lại",
                    Link = "https://nosbyn.com/",
                    Status = 1
                },
                new Brand
                {
                    ID = 2,
                    Name = "THE BLUE T-SHIRT",
                    Description = "Ra đời năm 2012, The BlueTshirt ban đầu mang đến thị trường Việt Nam các thiết kế áo thun đơn giản đi kèm những câu slogan đầy cảm hứng. Những thiết kế của The BlueTshirt là sự xen lẫn giữa nét thanh lịch và phóng khoáng, giữa sự nhẹ nhàng mà cá tính như chính người sáng lập ra nó. Dù là cô gái nhẹ nhàng yểu điệu hay cá tính, người ta vẫn có thể chọn cho mình một sản phẩm ưng ý ở The BlueTshirt.",
                    Link = "https://thebluetshirt.com/",
                    Status = 1
                }
        );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name = "Shirt",
                    Description = "1"
                },
                new Category
                {
                    ID = 2,
                    Name = "Short",
                    Description = "2"
                },
                new Category
                {
                    ID = 3,
                    Name = "Long-Skirt",
                    Description = "3"
                },
                new Category
                {
                    ID = 4,
                    Name = "Short-Skirt",
                    Description = "4"
                },
                new Category
                {
                    ID = 5,
                    Name = "Dress",
                    Description = "5"
                }
                );
            modelBuilder.Entity<ProductType>().HasData(
               new ProductType
               {
                   ID = 1,
                   Name = "New",
                   Description = "1"
               },
               new ProductType
               {
                   ID = 2,
                   Name = "IsUsed",
                   Description = "2"
               },
               new ProductType
               {
                   ID = 3,
                   Name = "Expected",
                   Description = "3"
               },
               new ProductType
               {
                   ID = 4,
                   Name = "Torn",
                   Description = "4"
               },
               new ProductType
               {
                   ID = 5,
                   Name = "Active",
                   Description = "5"
               },
               new ProductType
               {
                   ID = 6,
                   Name = "Inactive",
                   Description = "6"
               }
               );
        }

    }
}
