
using System.Text.Json.Serialization;

namespace CommonExercise.Models.Utils
{
    public class MemoryCard
    {
        [JsonPropertyName("imgSrc")]
        public string ImgSrc { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
