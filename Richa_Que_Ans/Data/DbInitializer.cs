using Richa_Que_Ans.Models;
using Richa_Que_Ans.Data;
using System;
using System.Linq;

namespace Richa_Que_Ans.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuestionContext context)
        {
            context.Database.EnsureCreated();
            var category = new Category[]
            {
            new Category {  Name = "Health" },
                new Category {Name = "Exercise" },
                new Category {  Name = "Dieting" }
            };
            foreach (Category c in category)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
            var question = new Question[]
            {
             new Question
                 {
                     QuestionName = "What is the correct time to wakeup for healthy life ?",
                     QuestionDateAndTime = "11/23/2021 11:30:25 PM",
                     CategoryID = 1
                 },
                new Question
                {
                    
                    QuestionName = "How much time daily one should exercise?",
                    QuestionDateAndTime = "10/22/2021 10:30:25 AM",
                    CategoryID = 2
                },
                new Question
                {
                    
                    QuestionName = "What is the best food ?",
                    QuestionDateAndTime = "03/10/2021 08:00:40 PM",
                    CategoryID = 3
                }
            };
            foreach (Question e in question)
            {
                context.Questions.Add(e);
            }
            context.SaveChanges();

            // Look for any students.

            var answer = new Answer[]
            {
           new Answer
                 {
                     
                     AnswerText = "Wake up early in the morning",
                     AnswerDateAndTime = "11/24/2021 10:30:25 PM",
                     QuestionID = 1
                 },
                new Answer
                {
                   
                    AnswerText = "Atleast 30 minutes daily",
                    AnswerDateAndTime = "11/22/2021 10:30:25 AM",
                    QuestionID = 2
                },
                new Answer
                {
                    
                    AnswerText = "Green vegetables and fruits are helathy diets",
                    AnswerDateAndTime = "05/10/2021 08:00:40 AM",
                    QuestionID = 3
                }
            };
            foreach (Answer s in answer)
            {
                context.Answers.Add(s);
            }
            context.SaveChanges();

            

            
        }
    }
}