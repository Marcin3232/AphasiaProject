using System;
using System.Text.Json.Serialization;

namespace AphasiaClientApp.Services.ExerciseResultHistoryServices
{
    public class ExerciseResultHistory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("jsonValue")]
        public string JsonValue { get; set; }
        [JsonPropertyName("createTime")]
        public DateTime CreateTime { get; set; }
    }
}