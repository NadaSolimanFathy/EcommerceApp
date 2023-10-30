using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Core.Context
{
    public class StoreDbContext:DbContext
    {


        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // i can add my connection string here
            //optionsBuilder.UseSqlServer("server=.;database=EcommerceStore;trusted connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure my relationships here 
            base.OnModelCreating(modelBuilder);
        }
        //Add my DbSets here " entities that will be converted to DB tables"
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    }
}
