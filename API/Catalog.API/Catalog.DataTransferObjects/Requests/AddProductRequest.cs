using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataTransferObjects.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage = "Ürün adı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ürün adı 50 karakterden uzun olamaz.")]
        [MinLength(3, ErrorMessage = "Ürün adı en az 3 karakterden oluşmalıdır.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public int? Stock { get; set; }
    }
}
