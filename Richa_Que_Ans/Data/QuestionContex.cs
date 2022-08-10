using Richa_Que_Ans.Models;
using Microsoft.EntityFrameworkCore;

namespace Richa_Que_Ans.Data
{
    public class QuestionContex:DbContext
    {
        public QuestionContex(DbContextOptions<QuestionContex> options) : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Question>().ToTable("Question");
        }

    }

}
