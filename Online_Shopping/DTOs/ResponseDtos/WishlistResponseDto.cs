using Ecommerce.Api.Models;

namespace Ecommerce.Api.DTOs.ResponseDto
{
    public class WishlistResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }       
        public int ProductId { get; set; }
    }
}
