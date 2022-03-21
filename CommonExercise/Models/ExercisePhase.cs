using System.Text.Json.Serialization;

namespace CommonExercise.Models
{
    public class ExercisePhase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }
        [JsonPropertyName("phaseNameId")]
        public int PhaseNameId { get; set; }
        [JsonPropertyName("kindId")]
        public int KindId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("kindName")]
        public string KindName { get; set; }
        [JsonPropertyName("kindDescription")]
        public string KindDescription { get; set; }
        [JsonPropertyName("kind")]
        public int Kind { get; set; }
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }
        [JsonPropertyName("typeName")]
        public string TypeName { get; set; }
        [JsonPropertyName("typeDescription")]
        public string TypeDescription { get; set; }
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("phaseDescription")]
        public string PhaseDescription { get; set; }
        [JsonPropertyName("soundSrc")]
        public string SoundSrc { get; set; }
        [JsonPropertyName("repeat")]
        public int Repeat { get; set; }
        [JsonPropertyName("isSoundEveryStep")]
        public bool IsSoundEveryStep { get; set; }
        [JsonPropertyName("isHelper")]
        public bool? IsHelper { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
        public bool IsDone { get; set; }
        public bool IsCurrent { get; set; }

    }
}
