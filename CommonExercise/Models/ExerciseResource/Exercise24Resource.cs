using CommonExercise.Models.Utils;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise24Resource
    {
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
        [JsonPropertyName("cards")]
        public List<MemoryCard> Cards { get; set; }
    }
}
