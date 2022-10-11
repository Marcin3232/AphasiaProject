using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public class UserPersonalDetailModel
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("houseNbr")]
        public int HouseNbr { get; set; }

        [JsonPropertyName("phoneNumber")]
        public int PhoneNumberd { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }
    }
}
