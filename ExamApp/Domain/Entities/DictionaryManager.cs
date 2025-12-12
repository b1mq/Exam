using System.IO;
using System.Text.Json;

namespace ExamApp.Domain.Entities
{
    public static class DictionaryManager
    {

        public static bool SerealizeDictionaryInJson(MyDictionary myDictionary,string directory)
        {
            if (!Directory.Exists(directory))
            {
               return false;
            }
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string path = Path.Combine(directory, $"{myDictionary.TranslatingLanguages}_Dictionary.json");
            File.WriteAllText(path, JsonSerializer.Serialize(myDictionary,options));
            return true;
        }
        public static MyDictionary DeserealizeDictionaryFromJson(string source)
        {
            if (!File.Exists(source))
            {
                return new MyDictionary { TranslatingLanguages = string.Empty };
            }
            var content = File.ReadAllText(source);
            if (string.IsNullOrWhiteSpace(content))
                return new MyDictionary { TranslatingLanguages = string.Empty };
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            try
            {
                return JsonSerializer.Deserialize<MyDictionary>(content,options)?? new MyDictionary { TranslatingLanguages = string.Empty };
            }
            catch (JsonException ex)
            {

                return new MyDictionary { TranslatingLanguages = string.Empty };
            }

        }
    }
}
