namespace ExamApp.Domain.Entities
{
    public static class DictionaryApp
    {
        private static void WelcomeText()
        {
            Console.WriteLine("****Welcome to Jangoo****");
            Console.WriteLine("*************************");
        }
        public static void MainMenu(MyDictionary myDictionary)
        {
            WelcomeText();
            var menuItems = new List<(string Title, Action Action)>
            {
                ("Add Translating", () => AddTranslateMenu(myDictionary)),
                ("Remove Translating", () => RemoveTranslateMenu(myDictionary)),
                ("Find Translating", () => FindTranslating(myDictionary)),
                ("Change Translating", () => ChangeTranslating(myDictionary)),
                ("Display Dictionary", () => myDictionary.DisplayDictionary())
            };
            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                for (int i = 0; i < menuItems.Count; i++)
                    Console.WriteLine($"{i + 1}. {menuItems[i].Title}");

                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= 1 && choice <= menuItems.Count)
                {
                    menuItems[choice - 1].Action();
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }
        public static void AddTranslateMenu(MyDictionary myDictionary)
        {
            Console.WriteLine("***Add words/ translated words to dictionary***");
            while (true)
            {
                Console.Write("Enter word (or type 'exit' to finish): ");
                string word = Console.ReadLine();
                if (word?.ToLower() == "exit")
                    break;

                List<string> translations = new List<string>();
                while (true)
                {
                    Console.Write("Enter translation (or type 'done' to finish translations): ");
                    string t = Console.ReadLine();
                    if (t?.ToLower() == "done")
                        break;

                }
                if (word != null && translations.All(n => n != null))
                {
                    myDictionary.AddTranslation(word,translations.ToArray());
                    Console.WriteLine("Succesfully added");
                }


                

            }
        }
        public static void RemoveTranslateMenu(MyDictionary myDictionary)
        {

        }
        public static void FindTranslating(MyDictionary myDictionary)
        {

        }
        public static void ChangeTranslating(MyDictionary myDictionary)
        {

        }
    }
}
