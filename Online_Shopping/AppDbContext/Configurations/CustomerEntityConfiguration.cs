using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Password).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(12).IsRequired();

            builder.HasMany(e => e.Shipments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Carts).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Payments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Payments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict); 
            builder.HasMany(e => e.Wishlists).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);

        }       

    }
}
