using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.SKU).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Stock).IsRequired();

            builder.HasMany(e => e.OrderItem).WithOne(e => e.Product).HasForeignKey(e => e.ProductId).IsRequired();
            builder.HasMany(e => e.Carts).WithOne(e => e.Product).HasForeignKey(e => e.ProductId).IsRequired();
            builder.HasMany(e => e.Wishlists).WithOne(e => e.Product).HasForeignKey(e => e.ProductId).IsRequired();
        }
       
    }
}
