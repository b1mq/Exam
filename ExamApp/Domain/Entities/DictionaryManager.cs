using System.IO;
using System.Text.Json;

namespace ExamApp.Domain.Entities
{
    public static class DictionaryManager
    {
        public static void SerealizeDictionaryInJson(MyDictionary myDictionary,string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException("Directory is not founded");
            }
            string path = Path.Combine(directory, $"{myDictionary.TranslatingLanguages}_Dictionary.json");
            File.WriteAllText(path, JsonSerializer.Serialize(myDictionary));
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
