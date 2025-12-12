using ExamApp.Domain.Entities;

var L = new MyDictionary { TranslatingLanguages = "Russian-German" };
L.AddTranslation("Привет", "Hallo");
L.AddTranslation("Пока", "Tschuss");
L.AddTranslation("Удобно", "Bequem");
//L.DisplayDictionary();

DictionaryApp.MainMenu(L);
