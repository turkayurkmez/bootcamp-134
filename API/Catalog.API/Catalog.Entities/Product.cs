using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
        public bool IsActive { get; set; } = true;


        public Category Category { get; set; }

    
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
      

   




    }
}
