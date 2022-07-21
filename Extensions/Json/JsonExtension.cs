using Newtonsoft.Json;

namespace Extensions.Json
{
    public static class JsonExtension<T>
    {
        public static T? Deserialize(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
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
                return JsonConvert.DeserializeObject<T>(Base64.Base64.Decode(data));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static string Serialize(T data) =>
            JsonConvert.SerializeObject(data);

        public static string Serialize64(T data) =>
            Base64.Base64.Encode(JsonConvert.SerializeObject(data));
    }
}
