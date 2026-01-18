namespace ExamApp.QuizApp
{
    public class QuizCollection
    {
        // хранить count of questions
        public required string CollectionName {  get; set; }
        public required string CollectionType { get; init; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public bool AddQuizToCollection(Quiz quiz)
        {
            if (quiz.TypeOfQuiz == CollectionType)
            {
                Quizzes.Add(quiz);
                return true;

            }else
            {
                return false;
            }
         
        }
        public void CreateQuizInCollection(string QuizName, string Question, string[] Answers, int[] RightAnswer)
        {
            Quizzes.Add(new Quiz(QuizName, CollectionType ,Question, Answers, RightAnswer));
        }
        public bool RemoveQuizFromCollection(string QuizName)
        {
            try
            {
                Quizzes.RemoveAll(x => x.QuizName == QuizName);
                return true;
            }catch (ArgumentNullException ex)
            {
                return false;
            }

        }
        public bool RemoveQuizFromCollection(Quiz quiz) => Quizzes.Remove(quiz);
        public Quiz GetQuiz(string QuizName) => Quizzes.FirstOrDefault(x => x.QuizName == QuizName);

        public void ReplaceQuiz(Quiz quizReplace, Quiz newQuiz) // придумать что то с логикой
        {
              int index = Quizzes.IndexOf(quizReplace);
              Quizzes[index] = newQuiz;

        }

    }
}
