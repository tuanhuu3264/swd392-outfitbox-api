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
        public DbSet<Domain.Entities.Type> Types { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Seed();
            
        }
    }
}
