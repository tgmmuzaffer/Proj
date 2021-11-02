using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj.Mvc.Models
{
    public class Search
    {
        [Required(ErrorMessage ="You must write something")]
        [MinLength(3,ErrorMessage = "Can not write less then 3 character")]
        [MaxLength(20, ErrorMessage ="Can not write more than 20 character")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage ="Can not write special characters")]
        public string SearchKeyword { get; set; }
        [Required(ErrorMessage ="Start qantity required")]
        [Range(0, 1000, ErrorMessage = "You must write between 0 and 1000")]
        public int Start { get; set; }
        [Required(ErrorMessage = "Start qantity required")]
        [Range(0, 1000, ErrorMessage = "You must write between 0 and 1000")]
        public int Finish { get; set; }
    }
}
