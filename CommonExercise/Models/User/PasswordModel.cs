using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public class PasswordModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("passOld")]
        public string PassOld { get; set; }

        [JsonPropertyName("passNew")]
        public string PassNew { get; set; }
    }
}
