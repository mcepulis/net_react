using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<QuizQuestion> QuizQuestions { get; set; }
        public required DbSet<Answer> Answers { get; set; }
        public required DbSet<HighScore> HighScores { get; set; }
    }
}
