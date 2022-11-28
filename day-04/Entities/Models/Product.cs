using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; } // property default : 0
        [Required(ErrorMessage ="Product Name is required.")]
        public String? Name { get; set; } // default : null
        [Required(ErrorMessage = "Price is required.")]
        public Decimal Price { get; set; }  // default: 0
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AtCreated { get; set; }

        public Product()
        {

        }

        public Product(int ıd, string? name, decimal price, string? description, string? ımageUrl)
        {
            Id = ıd;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = ımageUrl;
        }
    }
}
