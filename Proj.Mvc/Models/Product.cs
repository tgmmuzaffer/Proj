using System.ComponentModel.DataAnnotations;

namespace Proj.Mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [MinLength(3, ErrorMessage = "Title can not be less then three character")]
        [MaxLength(200, ErrorMessage = "Title can not be more than 200 character")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, 99999, ErrorMessage ="Quantity must be between 1 - 99999")]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Category is required")]
        public Category Category { get; set; }
    }

}
