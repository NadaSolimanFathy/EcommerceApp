using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(dept => dept.Id).IsRequired();
            builder.Property(dept => dept.Name).IsRequired().HasMaxLength(100);
            builder.Property(dept => dept.Description).IsRequired();
            builder.Property(dept => dept.Price).IsRequired().HasColumnType("money");
            builder.Property(dept => dept.PictureUrl).IsRequired();
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);



        }


    }
}
