
using Ecommerce.Api.Models;

namespace Ecommerce.Api.DTOs.ResponseDto
{
    public class OrderResponseDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerId { get; set; }       

        public int ShipmentId { get; set; }
      
        public int PaymentId { get; set; }
    }
}
