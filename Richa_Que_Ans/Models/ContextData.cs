using Microsoft.EntityFrameworkCore;
using Richa_Que_Ans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Richa_Que_Ans.Data
{
    public class ContexData
    {
   
        public ContexData(DbContextOptions<ContexData> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Question> Questions { get; set; }

        public DbSet<Models.Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "HTML" },
                new Category { CategoryID = 2, Name = "CSS" },
                new Category { CategoryID = 3, Name = "JavaScript" }
            );
            modelBuilder.Entity<Question>().HasData(
      new Question
      {
          QuestionID = 1,
          QuestionName = "How to use image tag in HTML ?",
          QuestionDateAndTime = "06/04/2022 11:30:25 PM",
          CategoryID = 1
      },
     new Question
     {
         QuestionID = 2,
         QuestionName = "How to read json data using js",
         QuestionDateAndTime = "06/04/2022 10:30:25 AM",
         CategoryID = 3
     },
     new Question
     {
         QuestionID = 3,
         QuestionName = "How to apply background colour to the html page ?",
         QuestionDateAndTime = "06/04/2022 08:00:40 PM",
         CategoryID = 2
     }
 );
            modelBuilder.Entity<Answers>().HasData(
                 new Answers
                 {
                     AnswerID = 1,
                     AnswerText = "use <img></img> tag in your HTML page",
                     AnswerDateAndTime = "07/04/2022 10:30:25 PM",
                     QuestionID = 1
                 },
                new Answers
                {
                    AnswerID = 2,
                    AnswerText = "using JSON.parse() method",
                    AnswerDateAndTime = "07/04/2022 10:30:25 PM",
                    QuestionID = 2
                },
                new Answers
                {
                    AnswerID = 3,
                    AnswerText = "in the .css file in body apply background:(colour you want)",
                    AnswerDateAndTime = "07/04/2022 08:00:40 AM",
                    QuestionID = 3
                }
            );
        }
    }
}
