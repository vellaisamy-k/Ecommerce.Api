namespace Ecommerce.Api.DTOs.ResponseDto
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public int CustomerId { get; set; }
    }
}
