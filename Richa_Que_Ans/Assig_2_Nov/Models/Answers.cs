using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Models
{
    public class Answers
    {
        [Key]
        public int AnswerID { get; set; }
        public int QuestionID { get; set; } //foreign key
        [Required(ErrorMessage = "Please input your question.")]
        public string AnswerText { get; set; }
        [Required(ErrorMessage = "This field cannot be empty.")]
        public string AnswerDateAndTime { get; set; }
    }
}
