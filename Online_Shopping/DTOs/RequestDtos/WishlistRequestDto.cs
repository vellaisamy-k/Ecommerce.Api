using Ecommerce.Api.Models;

namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class WishlistRequestDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }       
        public int ProductId { get; set; }
    }
}
