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
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(x => x.BuyerId).IsRequired().HasMaxLength(40);
        }
    }
}
