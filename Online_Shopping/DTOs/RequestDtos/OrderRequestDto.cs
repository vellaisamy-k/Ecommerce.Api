using Ecommerce.Api.Models;

namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class OrderRequestDto
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerId { get; set; }
       
        public int ShipmentId { get; set; }
       
        public int PaymentId { get; set; }
    }
}
