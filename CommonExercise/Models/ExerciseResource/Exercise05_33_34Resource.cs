using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise05_33_34Resource
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("soundSrc")]
        public string SoundSrc { get; set; }
    }
}
