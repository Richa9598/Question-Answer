using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Models
{
    public class ContextDBcs: DbContext

    {
        public ContextDBcs(DbContextOptions<ContextDBcs> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Health" },
                new Category { CategoryID = 2, Name = "Diet" },
                new Category { CategoryID = 3, Name = "Arts" }
            );
                       modelBuilder.Entity<Question>().HasData(
                 new Question
                 {
                     QuestionID = 1,
                     QuestionName = "What is the best Time to do exercise in morning ?",
                     QuestionDateAndTime = "11/04/2022 01:30:25 PM",
                     CategoryID = 1
                 },
                new Question
                {
                    QuestionID = 2,
                    QuestionName = "What type of food is best ?",
                    QuestionDateAndTime = "10/04/2022 16:50:25 AM",
                    CategoryID = 2
                },
                new Question
                {
                    QuestionID = 3,
                    QuestionName = "You do any external activities?",
                    QuestionDateAndTime = "03/04/2021 05:00:40 PM",
                    CategoryID = 3
                }
            );
            modelBuilder.Entity<Answers>().HasData(
                 new Answers
                 {
                     AnswerID = 1,
                     AnswerText = "wake up early and do atleat 30 min exercise",
                     AnswerDateAndTime = "11/24/2021 10:30:25 PM",
                     QuestionID = 1
                 },
                new Answers
                {
                    AnswerID = 2,
                    AnswerText = "Eat healthy food in the mornings",
                    AnswerDateAndTime = "11/22/2021 10:30:25 AM",
                    QuestionID = 2
                },
                new Answers
                {
                    AnswerID = 3,
                    AnswerText = "I learned dancing as an extra activity",
                    AnswerDateAndTime = "05/10/2021 08:00:40 AM",
                    QuestionID = 3
                }
            );
        }
    }
}

