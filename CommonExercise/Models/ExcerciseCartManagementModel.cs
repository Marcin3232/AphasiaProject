using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models
{
    public class ExcerciseCartManagementModel
    {
        [JsonPropertyName("exId")]
        public int Id { get; set; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("order")]
        public int order { get; set; }
    }
}
