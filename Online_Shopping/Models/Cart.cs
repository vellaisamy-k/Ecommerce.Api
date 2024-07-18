﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Api.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        public int CustomerId { get; set; }
        
        public int ProductId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }


    }
}