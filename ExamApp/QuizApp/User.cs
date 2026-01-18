namespace ExamApp.QuizApp
{
    public sealed class User {
        public required string Password { get; set; }
        public required string Login { get; set; }
        public required DateOnly BirthdayDate {  get; set; }
        public List<KeyValuePair<string, int>> PlayedQuizzes { get; set; } = new();
        
    };
}
