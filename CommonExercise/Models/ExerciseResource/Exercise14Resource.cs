using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise14Resource
    {
        [JsonPropertyName("nounSentence")]
        public string NounSentence { get; set; }
        [JsonPropertyName("pictureSrc")]
        public string PictureSrc { get; set; }
        [JsonPropertyName("nounSoundSrc")]
        public string NounSoundSrc { get; set; }
        [JsonPropertyName("nounSentenceSoundSrc")]
        public string NounSentenceSoundSrc { get; set; }
        [JsonPropertyName("nounInstructionSoundSrc")]
        public string NounInstructionSoundSrc { get; set; }
        [JsonPropertyName("verbs")]
        public List<Verb> Verbs { get; set; }

        public class Verb
        {
            [JsonPropertyName("verbText")]
            public string VerbText { get; set; }
            [JsonPropertyName("verbSoundSrc")]
            public string VerbSoundSrc { get; set; }
            [JsonPropertyName("verbPictureSrc")]
            public string VerbPictureSrc { get; set; }
        }
    }
}
