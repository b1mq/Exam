using System.Text.Json;
using ExamApp.Domain.Entities;

namespace ExamApp.QuizApp
{
    public class QuizManager
    {
        
        public bool SerealizeCollectionJSON(QuizCollection collection)
        {
            var directory = Directory.GetCurrentDirectory();
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string path = Path.Combine(directory,$"{collection.CollectionName}_Quiz.json");
            File.WriteAllText(path, JsonSerializer.Serialize(collection, options));
            return true;
        }
        public bool SerealizeUserJSON(User user)
        {
            var directory = Directory.GetCurrentDirectory();
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string path = Path.Combine(directory, $"{user.login}_User.json");
            File.WriteAllText(path, JsonSerializer.Serialize(user, options));
            return true;
        }
    }
}
