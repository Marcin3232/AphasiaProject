using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise02Resource
    {
        [JsonPropertyName("partOneVideoSrcs")]
        public List<string> PartOneVideoSrcs { get; set; }
        [JsonPropertyName("partTwoVideoSrcs")]
        public List<string> PartTwoVideoSrcs { get; set; }
        [JsonPropertyName("partThreeVideoSrcs")]
        public List<string> PartThreeVideoSrcs { get; set; }
        [JsonPropertyName("fullSentenceSound")]
        public List<string> FullSentenceSound { get; set; }
    }
}
