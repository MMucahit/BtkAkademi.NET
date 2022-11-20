using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; } // property default : 0
        public String? Name { get; set; } // default : null
        public Decimal Price { get; set; }  // default: 0

        public Product()
        {

        }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
