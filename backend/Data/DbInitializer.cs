
using Backend.Models;

namespace Backend.Data
{
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
                    Answers =
                    [
                        new Answer { Text = "Vilnius", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "What is the capital of France?",
                    QuestionType = "Radio",
                    Answers =
                    [
                        new Answer { Text = "Berlin", IsCorrect = false },
                        new Answer { Text = "Madrid", IsCorrect = false },
                        new Answer { Text = "Paris", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "Which db is open source?",
                    QuestionType = "Checkbox",
                    Answers =
                    [
                        new Answer { Text = "MySQL", IsCorrect = true },
                        new Answer { Text = "Oracle DB", IsCorrect = false },
                        new Answer { Text = "PostgreSQL", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "What is the capital of China?",
                    QuestionType = "Radio",
                    Answers =
                    [
                        new Answer { Text = "Shanghai", IsCorrect = false },
                        new Answer { Text = "Beijing", IsCorrect = true },
                        new Answer { Text = "Guangzhou", IsCorrect = false }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "What is the capital of Germany?",
                    QuestionType = "Radio",
                    Answers =
                    [
                        new Answer { Text = "Berlin", IsCorrect = true },
                        new Answer { Text = "Frankfurt", IsCorrect = false },
                        new Answer { Text = "Dresden", IsCorrect = false }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "What is the capital of Spain?",
                    QuestionType = "Radio",
                    Answers =
                    [
                        new Answer { Text = "Barselona", IsCorrect = false },
                        new Answer { Text = "Madrid", IsCorrect = true },
                        new Answer { Text = "Valencia", IsCorrect = false }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "Select backend languages:",
                    QuestionType = "Checkbox",
                    Answers =
                    [
                        new Answer { Text = "Java", IsCorrect = true },
                        new Answer { Text = "Javascript", IsCorrect = false },
                        new Answer { Text = "PHP", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "Select frontend languages:",
                    QuestionType = "Checkbox",
                    Answers =
                    [
                        new Answer { Text = "Javascript", IsCorrect = true },
                        new Answer { Text = "HTML", IsCorrect = true },
                        new Answer { Text = "CSS", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "Which city is the second largest in Lithuania?",
                    QuestionType = "Textbox",
                    Answers =
                    [
                        new Answer { Text = "Kaunas", IsCorrect = true }
                    ]
                });

                context.QuizQuestions.Add(new QuizQuestion
                {
                    QuestionText = "console.log(\"1\" === 1)?",
                    QuestionType = "Radio",
                    Answers =
                    [
                        new Answer { Text = "true", IsCorrect = false },
                        new Answer { Text = "false", IsCorrect = true }
                    ]
                });

                context.SaveChanges();
            }
        }
    }
}
