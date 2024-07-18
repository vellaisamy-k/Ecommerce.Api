using Ecommerce.Api.AppDbContext.Configurations;
using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Api.AppDbContext
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }
             

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; } 
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new  OrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new  CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new  WishlistEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new  CartEntityConfiguration());


        }

    }
}
