using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string QuestionName { get; set; }

        [Required(ErrorMessage = "This field cannot be empty.")]
        public string QuestionDateAndTime { get; set; }
        public int CategoryID { get; set; } // foreign key
        public Category Category { get; set; }
    }
}
