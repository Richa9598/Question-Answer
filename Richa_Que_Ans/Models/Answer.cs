using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Models
{
    public class Answer
    {

        [Key]
        public int AnswerID { get; set; }
        public int QuestionID { get; set; } //foreign key
        [Required(ErrorMessage = "Please submit your answer.")]
        public string AnswerText { get; set; }
        [Required(ErrorMessage = "Please enter todays date and time.")]
        public string AnswerDateAndTime { get; set; }
    }
}
