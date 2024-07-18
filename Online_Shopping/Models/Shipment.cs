using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Api.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        public DateTime ShipmentDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
