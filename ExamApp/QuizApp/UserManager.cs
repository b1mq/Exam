namespace ExamApp.QuizApp
{
    public static   class UserManager
    {
        public static bool ChangePassword(User user,string pass,string newpassword)
        {
            if(user.Password == pass)
            {
                user.Password = newpassword;
                return true;
            }
            return false;
            

        }
        public static bool ChangeLogin(User user,string pass,string newlogin)
        {
            if(user.Password == pass)
            {
                user.Login = newlogin;
                return true;
            }
            return false;
        }
        public static void DisplayUser(User user)
        {
            Console.WriteLine($"Login:{user.Login}");
            Console.WriteLine($"Password:{user.Password}");
            Console.WriteLine($"Birthday date:{user.BirthdayDate}");
            user.PlayedQuizzes.ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));

        }
        public static void AddPlayedQuizAndCountOfRightAnswers(User user,QuizCollection quizCollection,int answers)
        {
            user.PlayedQuizzes.Add(new KeyValuePair<string, int>(quizCollection.CollectionName, answers));
        }

    }
}
