using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string SKU { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; } = new HashSet<Wishlist>();


    }
}
