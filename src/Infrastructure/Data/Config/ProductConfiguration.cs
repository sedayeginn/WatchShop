using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand)    //propductın bir brandı vardır
                .WithMany()   //her bir brandın productları vardır
                .HasForeignKey(x => x.BrandId);
                
        }
    }
}
