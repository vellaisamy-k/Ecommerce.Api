using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models
{
    public class Customer
    {
        [Key]
        
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
   
        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }

}
