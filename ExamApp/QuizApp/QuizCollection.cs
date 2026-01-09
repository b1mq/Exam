namespace ExamApp.QuizApp
{
    public class QuizCollection
    {
        public required string CollectionName {  get; set; }
        public required string CollectionType { get; init; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public void AddQuizToCollection(Quiz quiz)
        {
            if(quiz.TypeOfQuiz == CollectionType) Quizzes.Add(quiz);
        }
        public void CreateQuizInCollection(string QuizName, string Question, string[] Answers, int[] RightAnswer)
        {
            Quizzes.Add(new Quiz(QuizName, CollectionType ,Question, Answers, RightAnswer));
        }
        public void RemoveQuizFromCollection(string QuizName) => Quizzes.RemoveAll(x => x.QuizName == QuizName);
        public void RemoveQuizFromCollection(Quiz quiz) => Quizzes.Remove(quiz);
        public Quiz GetQuiz(string QuizName) => Quizzes.FirstOrDefault(x => x.QuizName == QuizName);

        public void ReplaceQuiz(Quiz quizReplace, Quiz newQuiz)
        {
            int index = Quizzes.IndexOf(quizReplace);
            Quizzes[index] = newQuiz;
        }

    }
}
