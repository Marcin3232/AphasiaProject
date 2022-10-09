using System.Text.Json.Serialization;

namespace CommonExercise.Models.Request;

public class RequestKey
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
}
