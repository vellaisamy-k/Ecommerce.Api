using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.PaymentDate).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.PaymentMethod).HasMaxLength(100).IsRequired();
            
            builder.HasMany(e => e.Orders).WithOne(e => e.Payment).HasForeignKey(e => e.PaymentId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }

    }
}
