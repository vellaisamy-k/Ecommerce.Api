using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Api.AppDbContext.Configurations
{
    public class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ShipmentDate).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.City).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Country).HasMaxLength(100).IsRequired();
            builder.Property(e => e.ZipCode).HasMaxLength(10).IsRequired();

            builder.HasMany(e => e.Orders).WithOne(e => e.Shipment).HasForeignKey(e => e.ShipmentId).IsRequired().OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
