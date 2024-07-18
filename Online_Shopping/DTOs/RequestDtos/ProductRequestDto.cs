﻿namespace Ecommerce.Api.DTOs.RequestDtos
{
    public class ProductRequestDto
    {
        public string SKU { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
