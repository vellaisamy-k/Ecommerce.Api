using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
    {       
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(e => e.Id);
            builder.Property(e=> e.Quantity).IsRequired();
        }

    }
}
