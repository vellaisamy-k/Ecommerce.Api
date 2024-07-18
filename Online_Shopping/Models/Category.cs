﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
