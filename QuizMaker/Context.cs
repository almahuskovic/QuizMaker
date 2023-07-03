using Microsoft.EntityFrameworkCore;
using QuizMaker.Model.Entities;

namespace QuizMaker
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizQuestion> QuizQuestion { get; set; }
        public DbSet<QuizzesQuestions> QuizzesQuestions { get; set; }
    }
}
