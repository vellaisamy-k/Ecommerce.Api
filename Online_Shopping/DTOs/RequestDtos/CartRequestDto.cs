
namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class CartRequestDto
    {

        public int Quantity { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
