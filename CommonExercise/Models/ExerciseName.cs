using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models
{
    public class ExerciseName
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("imageSrc")]
        public string ImageSrc { get; set; }
        [JsonPropertyName("idExerciseTask")]
        public string IdExerciseTask { get; set; }
    }
}
