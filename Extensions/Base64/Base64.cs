using System.Text;

namespace Extensions.Base64;

public class Base64
{
    public static string Encode(string data) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

    public static string Decode(string data) =>
        Encoding.UTF8.GetString(Convert.FromBase64String(data));
}
