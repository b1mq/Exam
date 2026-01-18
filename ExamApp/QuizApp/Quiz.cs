namespace ExamApp.QuizApp
{
    public sealed record Quiz(string QuizName, string TypeOfQuiz, string Question, string[] Answers, int[] RightAnswer) 
    {
        // хранится RightAnswer номер в Answers
        public string GetQuestion() => Question;
        public void DisplayAnswers() => Answers.ToList().ForEach(x => Console.WriteLine(x));
        public void ShowQuizInfo()
        {
            Console.WriteLine(QuizName);
            Console.WriteLine(TypeOfQuiz);
            Console.WriteLine(Question);
        }
    }



}
