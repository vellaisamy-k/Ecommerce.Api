﻿namespace Ecommerce.Api.DTOs.ResponseDto
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
