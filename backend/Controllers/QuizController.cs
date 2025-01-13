using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _context.QuizQuestions
                .Include(q => q.Answers)
                .ToListAsync();
            return Ok(questions);
        }

        [HttpPost("submit-quiz")]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmission submission)
        {
            var questions = await _context.QuizQuestions.Include(q => q.Answers).ToListAsync();
            int score = 0;

            foreach (var userAnswer in submission.Answers)
            {
                var question = questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);
                if (question == null) continue;

                if (question.QuestionType == "Radio")
                {
                    if (question.Answers.Any(a => a.Id == userAnswer.SelectedAnswerIds.FirstOrDefault() && a.IsCorrect))
                        score += 100;
                }
                else if (question.QuestionType == "Checkbox")
                {
                    var correctAnswers = question.Answers.Count(a => a.IsCorrect);
                    var correctSelected = question.Answers.Count(a => userAnswer.SelectedAnswerIds.Contains(a.Id) && a.IsCorrect);
                    score += (int)Math.Ceiling((double)(100 * correctSelected) / correctAnswers);
                }
                else if (question.QuestionType == "Textbox")
                {
                    var correctAnswer = question.Answers.FirstOrDefault()?.Text ?? string.Empty;
                    if (string.Equals(correctAnswer, userAnswer.TextAnswer, StringComparison.OrdinalIgnoreCase))
                        score += 100;
                }
            }

            var highScore = new HighScore
            {
                Email = submission.Email,
                Score = score,
                DateTime = DateTime.Now
            };

            _context.HighScores.Add(highScore);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Quiz submitted successfully!", Score = score });
        }

        [HttpGet("high-scores")]
        public async Task<IActionResult> GetHighScores()
        {
            var topScores = await _context.HighScores
                .OrderByDescending(h => h.Score)
                .ThenBy(h => h.DateTime)
                .Take(10)
                .ToListAsync();
            return Ok(topScores);
        }
    }
}
