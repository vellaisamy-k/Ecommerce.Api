using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {      
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(e => e.Products).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId).IsRequired();
        }

    }
}
