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
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Basket>()
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.BasketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
