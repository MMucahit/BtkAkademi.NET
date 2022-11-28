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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId); // Primary Key
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).HasDefaultValue("...");
            builder.HasData(
                new Category()
                {
                    CategoryId= 1,
                    Name = "Books",
                    Description = "This is a book category"

                },
                new Category()
                {
                    CategoryId = 2,
                    Name= "Electronics",
                    Description = "This is a electronics category"
                },
                new Category()
                {
                   CategoryId = 3,
                   Name= "Smart Phone",
                   Description = "This is a Smart Phone category"
                }
                );
        }
    }
}
