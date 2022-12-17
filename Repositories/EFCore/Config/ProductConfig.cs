using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                // Ürünlerde silinir. SetNull => ürünleri null yapar.
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Name = "HP ZBook",
                    Price = 17_000,
                    CategoryId = 1,
                },
                new Product()
                {
                    Id = 2,
                    Name = "AirPods",
                    Price = 5_000,
                    CategoryId = 2,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Samsun Galaxy Note FE",
                    Price = 7_000,
                    CategoryId = 3,
                }
                );
        }
    }
}
