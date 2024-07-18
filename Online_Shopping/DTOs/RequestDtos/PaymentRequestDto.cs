
namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class PaymentRequestDto
    {
        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public int CustomerId { get; set; }
    }
}
