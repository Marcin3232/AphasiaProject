using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public class PatientModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
