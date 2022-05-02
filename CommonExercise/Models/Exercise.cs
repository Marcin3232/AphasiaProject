using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonExercise.Models
{
    public class Exercise
    {
        [JsonPropertyName("exerciseInformation")]
        public ExerciseInformation ExerciseInformation { get; set; }
        [JsonPropertyName("phases")]
        public List<ExercisePhase> Phases { get; set; }
        [JsonPropertyName("exerciseResource")]
        public dynamic ExerciseResource { get; set; }
    }
}
