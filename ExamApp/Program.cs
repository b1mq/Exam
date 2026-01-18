using ExamApp.Domain.Entities;
using ExamApp.QuizApp;
//var L = new MyDictionary { TranslatingLanguages = "Russian-German" };
//L.AddTranslation("Привет", "Hallo");
//L.AddTranslation("Пока", "Tschuss");
//L.AddTranslation("Удобно", "Bequem");
////L.DisplayDictionary();

//DictionaryApp.MainMenu(L);

var user1 = new User("valera", 123, new DateOnly(2000, 1, 1));
var user2 = new User("anna", 456, new DateOnly(1999, 12, 31));
string path = @"C:\Users\Admin\Desktop\";
QuizManager.AddOrUpdateUser(user1,path);
QuizManager.AddOrUpdateUser(user2,path);

Console.WriteLine(Directory.GetCurrentDirectory());