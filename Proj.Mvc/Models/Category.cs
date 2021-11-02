using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proj.Mvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Can not be empty")]
        [MinLength(3, ErrorMessage ="Can not be less than 3 charecter")]
        [MaxLength(100, ErrorMessage ="Can not be more than 100 charecter")]
        public string CategoryName { get; set; }
        [Range(1, 99999, ErrorMessage = "Quantity must be between 1 - 99999")]
        public int MinStockQuantity { get; set; }
        public List<Product> Products { get; set; }
    }
}
