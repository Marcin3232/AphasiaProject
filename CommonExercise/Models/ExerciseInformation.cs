using System.Text.Json.Serialization;

namespace CommonExercise.Models
{
    public class ExerciseInformation
    {
        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }
        [JsonPropertyName("exerciseNameId")]
        public int ExerciseNameId { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("imageSrc")]
        public string ImageSrc { get; set; }
        [JsonPropertyName("exerciseTaskId")]
        public string ExerciseTaskId { get; set; }
    }
}
