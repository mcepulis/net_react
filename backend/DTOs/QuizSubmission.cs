namespace Backend.DTOs
{
    public class QuizSubmission
    {
        public string Email { get; set; } = string.Empty;
        public List<UserAnswer> Answers { get; set; } = new List<UserAnswer>();
    }

    public class UserAnswer
    {
        public int QuestionId { get; set; }
        public List<int> SelectedAnswerIds { get; set; } = new List<int>();
        public string? TextAnswer { get; set; }
    }
}
