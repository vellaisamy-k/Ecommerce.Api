using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Ecommerce.Api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime OrderDate { get; set; }
               
        public decimal TotalPrice { get; set; }
               
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }       
           
        public int PaymentId { get; set; }         

       public virtual Payment Payment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
