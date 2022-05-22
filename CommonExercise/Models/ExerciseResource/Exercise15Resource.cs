using System.Text.Json.Serialization;

namespace CommonExercise.Models.ExerciseResource
{
    public class Exercise15Resource
    {
        [JsonPropertyName("picturesSrcs")]
        public string[] PicturesSrcs { get;  set; }
        [JsonPropertyName("mainExpression")]
        public VerbExpression MainExpression { get; set; }
        [JsonPropertyName("wrongExpression")]
        public VerbExpression WrongExpression { get;  set; }
        [JsonPropertyName("usingQuestions")]
        public VerbExpression[] UsingQuestions { get;  set; }
        [JsonPropertyName("usingAnswers")]
        public VerbExpression[] UsingAnswers { get;  set; }
        [JsonPropertyName("usingExpressionParts")]
        public string[] UsingExpressionParts { get;  set; }

        public class VerbExpression
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
            [JsonPropertyName("soundSrc")]
            public string SoundSrc { get; set; }
            [JsonPropertyName("id")]
            public int Id { get; set; }
        }
    }
}
