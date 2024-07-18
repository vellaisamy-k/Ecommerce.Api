namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class ShipmentRequestDto
    {
        public DateTime ShipmentDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public int CustomerId { get; set; }
    }
}
