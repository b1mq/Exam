using System.Collections.Generic;
using System.Text.Json;

namespace ExamApp.Domain.Entities
{
    public class MyDictionary
    {
        public required string TranslatingLanguages {  get; set; }
        public Dictionary<string, string[]> Languages { get; set; } = new Dictionary<string, string[]>();
        public void AddTranslation(string original,params string[] translate) => Languages.Add(original, translate);
        public void ChangeWord(string wordToChange,string change)
        {
            if (Languages.ContainsKey(wordToChange))
            {
                var temp = Languages[wordToChange];
                Languages.Remove(wordToChange);
                AddTranslation(change, temp);
            }else
            {
                throw new ArgumentException("Original word does not contain in dictionary");
            }
        }

        public void RemoveWord(string key)
        {
            if (!Languages.ContainsKey(key)) throw new ArgumentNullException("Key does not contain in Dictionary"); 
            Languages.Remove(key);


        }
        public string[] FindTranslation(string key)
        {
            if (!Languages.ContainsKey(key)) throw new ArgumentNullException("Key does not contain in Dictionary");
            return Languages[key].ToArray();
        }
        public void ChangeTranslation(string wordToChange, params string[] translation) 
        {
            if (!Languages.ContainsKey(wordToChange)) throw new ArgumentNullException("Key does not contain in Dictionary");
            Languages[wordToChange] = translation;
        }
        public void DisplayDictionary() => Languages.ToList().ForEach(x =>Console.WriteLine($"{x.Key}: {string.Join(", ", x.Value)}"));
        
    }
}
