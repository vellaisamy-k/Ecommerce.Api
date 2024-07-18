using Ecommerce.Api.Models;

namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class OrderItemRequestDto
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int OrderId { get; set; }
       
        public int ProductId { get; set; }
    }
}
