using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Api.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }
       
        public decimal Amount { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
