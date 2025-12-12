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
                ("Change Translate of word", () => ChangeTranslating(myDictionary)),
                ("Change Word of translating", () => ChangeWordTranslating(myDictionary)),
                ("Display Dictionary", () => myDictionary.DisplayDictionary()),
                ("Exit", () => Environment.Exit(0))
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
                Console.Write("Enter word (or type '@@' to finish): ");
                string word = Console.ReadLine();
                if (word?.ToLower() == "@@")
                    break;

                List<string> translations = new List<string>();
                while (true)
                {
                    Console.Write("Enter translation (or type '@' to finish translations): ");
                    string t = Console.ReadLine();
                    if (t?.ToLower() == "@")
                        break;
                    translations.Add(t);

                }
                if (!string.IsNullOrWhiteSpace(word) && translations.All(n => !string.IsNullOrWhiteSpace(n)))
                {
                    myDictionary.AddTranslation(word,translations.ToArray());
                    Console.WriteLine("Succesfully added");
                }
                

            }
        }
        public static void RemoveTranslateMenu(MyDictionary myDictionary)
        {
            Console.WriteLine($"***Remove translate in {nameof(myDictionary)}***");
            while (true) 
            {
                Console.Write("Enter word (or type '@' to finish): ");
                string word = Console.ReadLine();
                if (word?.ToLower() == "@")
                    break;
                if (!string.IsNullOrWhiteSpace(word))
                {
                    var res = myDictionary.RemoveWord(word);
                    if (!res )
                    {
                        Console.WriteLine("Key does not exist in the dictionary"); 
                    }
                    else
                    {
                        Console.WriteLine("Succesfully");
                    }
                }
            }
        }
        public static void FindTranslating(MyDictionary myDictionary)
        {
            Console.WriteLine($"***Find word in {nameof(myDictionary)}***");
            while (true)
            {
                Console.Write("Enter word (or type '@' to finish): ");
                Console.WriteLine();
                string word = Console.ReadLine();
                if (word?.ToLower() == "@")
                    break;
                if (!string.IsNullOrWhiteSpace(word))
                {
                    var result = myDictionary.FindTranslation(word);
                    if (result == null)
                    {
                        Console.WriteLine("Word is not found");
                    }
                    else
                    {
                        result.ToList().ForEach(x => Console.Write(x + " "));
                        Console.WriteLine();
                    }
                }else
                {
                    Console.WriteLine("Word is empty,please try again");
                }


            }
        }
        public static void ChangeTranslating(MyDictionary myDictionary)
        {
            Console.WriteLine($"***Change translate of word   in {nameof(myDictionary)}***");
            while (true)
            {
                Console.Write("Enter word to change his translate (or type '@' to finish)");
                string word = Console.ReadLine();
                if (word?.ToLower() == "@")
                    break;

                if (!string.IsNullOrWhiteSpace(word))
                {
                    List<string> translations = new List<string>();
                    while (true)
                    {
                        Console.Write($"Enter new translation of {word} (or type '@@' to finish translations): ");
                        string t = Console.ReadLine();
                        if (t?.ToLower() == "@@")
                            break;
                        translations.Add(t);


                    }
                    if (translations.All(n => !string.IsNullOrWhiteSpace(n)))
                    {
                        myDictionary.ChangeTranslation(word, translations.ToArray());
                    }
                }

            }
        }
            public static void ChangeWordTranslating(MyDictionary myDictionary)
        {
            Console.WriteLine($"***Change translate of word   in {nameof(myDictionary)}***");
            while (true)
            {
                Console.Write("Enter word  to change (or type '@' to finish)");
                string word = Console.ReadLine();
                if (word?.ToLower() == "@")
                    break;

                if (!string.IsNullOrWhiteSpace(word))
                {
                    Console.WriteLine("Enter change of word(or type '@@' to finish): ");
                    string change = Console.ReadLine();
                    if (change?.ToLower() == "@@")
                    {
                        break;
                    }
                    if(!string.IsNullOrWhiteSpace(change))
                    {
                        var result = myDictionary.ChangeWord(word, change);
                        if (!result)
                        {
                            Console.WriteLine("Original word does not contain in dictionary"); 
                        }
                        else {
                            Console.WriteLine("Succesfully");
                        }
                    }

                }
            }
        }
    }
}
