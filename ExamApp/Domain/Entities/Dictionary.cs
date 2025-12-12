using System.Collections.Generic;
using System.Text.Json;

namespace ExamApp.Domain.Entities
{
    public class MyDictionary
    {
        public required string TranslatingLanguages {  get; set; }
        public Dictionary<string, string[]> Languages { get; set; } = new Dictionary<string, string[]>();
        public void AddTranslation(string original, params string[] translate) {
            if(!Languages.ContainsKey(original))
            {
                Languages.Add(original, translate);
            }
            else
            {
                Languages[original] = translate;
            }
        
        } 
        public bool ChangeWord(string wordToChange,string change)
        {
            if (Languages.ContainsKey(wordToChange))
            {
                var temp = Languages[wordToChange];
                Languages.Remove(wordToChange);
                AddTranslation(change, temp);
                return true;
            }
            return false;
        }

        public bool RemoveWord(string key)
        {
            if (!Languages.ContainsKey(key)) return false;
            Languages.Remove(key);
            return true;


        }
        public string[] FindTranslation(string key)
        {
            if (!Languages.ContainsKey(key)) throw new KeyNotFoundException("Key does not exist in the dictionary");
            return Languages[key].ToArray();
        }
        public void ChangeTranslation(string wordToChange, params string[] translation) 
        {
            if (!Languages.ContainsKey(wordToChange)) throw new KeyNotFoundException("Key does not exist in the dictionary");
            Languages[wordToChange] = translation;
        }
        public void DisplayDictionary() => Languages.ToList().ForEach(x =>Console.WriteLine($"{x.Key}: {string.Join(", ", x.Value)}"));
        
    }
}
