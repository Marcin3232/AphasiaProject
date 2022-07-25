using System;
using System.Text.Json.Serialization;

namespace CommonExercise.Models;

public class ExerciseResultHistory
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
    [JsonPropertyName("jsonValue")]
    public string JsonValue { get; set; } = string.Empty;
    [JsonPropertyName("createTime")]
    public DateTime CreateTime { get; set; }
}
