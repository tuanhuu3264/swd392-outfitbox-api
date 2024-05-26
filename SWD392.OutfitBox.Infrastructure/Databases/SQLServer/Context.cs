using FAMS.Core.Databases;
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryPackage> CategoryPackages { get; set; }
        public DbSet<FavouriteProduct> Favourites { get; set; }
        public DbSet<ItemInUserPackage> ItemInUserPackages { get; set; }
        public DbSet<ProductReturnOrder> ProductReturnOrders { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Package> Packages { get; set; }    
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ReturnOrder> ReturnOrders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }    
        public DbSet<Role> Roles { get; set; }
        public DbSet<CustomerPackage> CustomerPackages { get; set; }
        public DbSet<Wallet> Wallets { get; set; }  
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Seed();
            modelBuilder.Entity<CustomerPackage>().HasOne(x=>x.Customer).WithMany(x=>x.UserPackages).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReturnOrder>().HasOne(x=>x.Customer).WithMany(x=>x.ReturnOrders).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Deposit>().HasMany(x => x.Transactions).WithOne(x => x.Deposit).HasForeignKey(x => x.DepositId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CustomerPackage>().HasOne(x => x.Transaction).WithMany(x=>x.CustomerPackages).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
