using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id); // Primary Key
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ImageUrl).HasDefaultValue("/images/products/default.jpg");
            builder.Property(p => p.AtCreated).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Description).HasDefaultValue("...");
            builder.HasData(
                new Product()
                {
                    Id= 1,
                    Name = "HP ZBook",
                    Price = 17_000,

                },
                new Product()
                {
                    Id= 2,
                    Name= "AirPods",
                    Price = 5_000,
                },
                new Product()
                {
                   Id= 3,
                   Name= "Samsun Galaxy Note FE",
                   Price = 7_000,
                }
                );
        }
    }
}
