using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Models
{
    public class Category
    {
            
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        public string Name { get; set; }
    }
}

