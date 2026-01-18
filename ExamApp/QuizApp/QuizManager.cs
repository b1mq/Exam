using System.Text.Json;
using System.Text.Json.Serialization;
using ExamApp.Domain.Entities;

namespace ExamApp.QuizApp
{
    public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateOnly.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(Format));
    }
    public sealed class QuizManager
    {
        private static readonly string DefaultUserFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.json");

        private static JsonSerializerOptions GetJsonOptions()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            options.Converters.Add(new DateOnlyJsonConverter());
            return options;
        }

        public static bool SerealizeCollectionJSON(QuizCollection collection)
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
        public static bool AddOrUpdateUser(User user, string? filePath = null)
        {
            filePath ??= DefaultUserFile;

            try
            {
                UsersCollection collection;


                if (File.Exists(filePath))
                {
                    collection = JsonSerializer.Deserialize<UsersCollection>(File.ReadAllText(filePath), GetJsonOptions())
                                 ?? new UsersCollection();
                }
                else
                {
                    collection = new UsersCollection();
                }


                collection.Users.RemoveAll(u => u.Login == user.Login);
                collection.Users.Add(user);
                File.WriteAllText(filePath, JsonSerializer.Serialize(collection, GetJsonOptions()));
                return true;
            }
            catch
            {
                return false;
            }
        }

  
        public static User? GetUser(string login, string? filePath = null)
        {
            filePath ??= DefaultUserFile;

            if (!File.Exists(filePath))
                return null;

            var collection = JsonSerializer.Deserialize<UsersCollection>(File.ReadAllText(filePath), GetJsonOptions());
            return collection?.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
