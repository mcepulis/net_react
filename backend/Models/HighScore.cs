namespace Backend.Models
{
    public class HighScore
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
