using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<HighScore> HighScores { get; set; }
    }
}
