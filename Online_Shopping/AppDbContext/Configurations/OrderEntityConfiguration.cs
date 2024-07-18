using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {      
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.TotalPrice).IsRequired();

            builder.HasMany(e => e.OrderItems).WithOne(e => e.Order).HasForeignKey(e => e.OrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }

    }
}
