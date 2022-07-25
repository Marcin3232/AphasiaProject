using System.Text.Json;

namespace Extensions.Json
{
    public static class JsonExtension<T>
    {
        public static T? Deserialize(string data)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(data);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static T? Deserialize64(string data)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(Base64.Base64.Decode(data));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static string Serialize(T data) =>
            JsonSerializer.Serialize(data);

        public static string Serialize64(T data) =>
            Base64.Base64.Encode(JsonSerializer.Serialize(data));
    }
}
