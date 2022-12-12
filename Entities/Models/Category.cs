using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Collection Navigation Property
        public ICollection<Product>? Products { get; set; }

        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        public Category()
        {

        }

    }


}
