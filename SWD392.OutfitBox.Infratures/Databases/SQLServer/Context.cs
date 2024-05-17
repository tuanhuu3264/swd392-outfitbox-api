using FAMS.Core.Databases;
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = SWD392.OutfitBox.Domain.Entities.ProductType;

namespace SWD392.OutfitBox.Infrastructure.Databases.SQLServer
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryPackage> CategoryPackages { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<ItemInUserPackage> ItemInUserPackages { get; set; }
        public DbSet<ItemInUserPackageReturnOrder> ItemInUserPackageReturnOrders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Package> Packages { get; set; }    
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ReturnOrder> ReturnOrders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }    
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserPackage> UserPackages { get; set; }
        public DbSet<Wallet> Wallets { get; set; }  
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Seed();
            modelBuilder.Entity<UserPackage>().HasOne(x=>x.User).WithMany(x=>x.UserPackages).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReturnOrder>().HasOne(x=>x.User).WithMany(x=>x.ReturnOrders).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
