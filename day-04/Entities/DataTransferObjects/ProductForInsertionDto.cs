﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record class ProductForInsertionDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public String? Name { get; init; } // default : null
        [Required(ErrorMessage = "Price is required.")]
        public Decimal Price { get; init; }  // default: 0
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public int? CategoryId { get; init; }
    }
}