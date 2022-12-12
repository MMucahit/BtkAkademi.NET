using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record class ProductForUpdateDto
    {
        public int Id { get; init; } // property default : 0

        [Required(ErrorMessage = "Product Name is required.")]
        public String? Name { get; init; } // default : null
        [Required(ErrorMessage = "Price is required.")]
        public Decimal Price { get; init; }  // default: 0
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public DateTime? AtCreated { get; init; }

        public int? CategoryId { get; init; }
    }
}
