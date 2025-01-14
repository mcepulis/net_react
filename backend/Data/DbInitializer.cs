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
                QuestionText = "What is the capital of Lithuania?",
                QuestionType = "Textbox",
                Answers = new List<Answer>
                {
                    new() { Text = "Vilnius", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the capital of France?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new() { Text = "Berlin", IsCorrect = false },
                    new() { Text = "Madrid", IsCorrect = false },
                    new() { Text = "Paris", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Select programming languages:",
                QuestionType = "Checkbox",
                Answers = new List<Answer>
                {
                    new() { Text = "C#", IsCorrect = true },
                    new() { Text = "HTML", IsCorrect = false },
                    new() { Text = "Python", IsCorrect = true }
                }
            });

             context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the capital of China?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new() { Text = "Shanghai", IsCorrect = false },
                    new() { Text = "Beijing", IsCorrect = true },
                    new() { Text = "Guangzhou", IsCorrect = false }
                }
            });

             context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the capital of Germany?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new() { Text = "Berlin", IsCorrect = true },
                    new() { Text = "Frankfurt", IsCorrect = false },
                    new() { Text = "Dresden", IsCorrect = false }
                }
            });

             context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "What is the capital of Spain?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new() { Text = "Barselona", IsCorrect = false },
                    new() { Text = "Madrid", IsCorrect = true },
                    new() { Text = "Valencia", IsCorrect = false }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Select backend languages:",
                QuestionType = "Checkbox",
                Answers = new List<Answer>
                {
                    new() { Text = "Java", IsCorrect = true },
                    new() { Text = "Javascript", IsCorrect = false },
                    new() { Text = "PHP", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "Select frontend languages:",
                QuestionType = "Checkbox",
                Answers = new List<Answer>
                {
                    new() { Text = "Javascript", IsCorrect = false },
                    new() { Text = "HTML", IsCorrect = true },
                    new() { Text = "CSS", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "which city is the second largest in Lithuania?",
                QuestionType = "Textbox",
                Answers = new List<Answer>
                {
                    new() { Text = "Kaunas", IsCorrect = true }
                }
            });

            context.QuizQuestions.Add(new QuizQuestion
            {
                QuestionText = "console.log(\"1\" === 1)?",
                QuestionType = "Radio",
                Answers = new List<Answer>
                {
                    new() { Text = "true", IsCorrect = false },
                    new() { Text = "false", IsCorrect = true },
                }
            });

            context.SaveChanges();
        }
    }
}
