namespace Backend.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty; 
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
