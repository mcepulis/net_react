using Backend.Data;
using Backend.Models;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.QuizQuestions.Any())
        {
            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the capital of France?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Berlin", IsCorrect = false },
                    new Answer { Text = "Madrid", IsCorrect = false },
                    new Answer { Text = "Paris", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Select programming languages:",
                QuestionType = "Checkbox",
                Answers = new List<Answer>
                {
                    new Answer { Text = "C#", IsCorrect = true },
                    new Answer { Text = "HTML", IsCorrect = false },
                    new Answer { Text = "Python", IsCorrect = true }
                }
            });

            context.SaveChanges();
        }
    }
}
