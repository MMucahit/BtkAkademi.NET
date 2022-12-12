namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; } // property default : 0
        public String? Name { get; set; } // default : null
        public Decimal Price { get; set; }  // default: 0
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AtCreated { get; set; }

        // Navigation Property
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

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
