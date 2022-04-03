using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise07Resource
    {
        [JsonPropertyName("noun")]
        public string Noun { get;  set; }
        [JsonPropertyName("description")]
        public string Description { get;  set; }
        [JsonPropertyName("pictureSrc")]
        public string PictureSrc { get;  set; }
        [JsonPropertyName("nounSoundSrc")]
        public string NounSoundSrc { get;  set; }
        [JsonPropertyName("DescrSoundSrc")]
        public string DescrSoundSrc { get;  set; }
        [JsonPropertyName("questionSoundSrc")]
        public string QuestionSoundSrc { get;  set; }
    }
}
