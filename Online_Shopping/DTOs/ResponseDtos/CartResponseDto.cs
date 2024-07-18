namespace Ecommerce.Api.DTOs.ResponseDto
{
    public class CartResponseDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
