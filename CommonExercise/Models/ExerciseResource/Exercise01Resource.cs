using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise01Resource
    {
        [JsonPropertyName("word")]
        public string Word { get; set; }
        [JsonPropertyName("wordSoundSrc")]
        public string WordSoundSrc { get; set; }
        [JsonPropertyName("instructionSoundSrc")]
        public string InstructionSoundSrc { get; set; }
        [JsonPropertyName("picturesSrcs")]
        public string[] PicturesSrcs { get; set; }
    }
}
