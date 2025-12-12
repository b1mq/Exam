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
                throw new DirectoryNotFoundException("Directory is not founded");
            }
            var content = File.ReadAllText(source);
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Source file is empty", nameof(source));
            try
            {
                return JsonSerializer.Deserialize<MyDictionary>(content)?? throw new JsonException("Deserialized object is null");
            }
            catch (JsonException ex)
            {

                throw new JsonException("Cannot serealize JSON file",ex);
            }

        }
    }
}
