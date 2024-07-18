using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Ecommerce.Api.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
       
        public int Quantity { get; set; }
       
        public decimal Price { get; set; }
                
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
                
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
