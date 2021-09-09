using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AphasiaProject.Models.Auth
{
    public class AppLoginViewModel
    {
        //[Required]
        public string UserName { get; set; }

        //[Required]
      //  [JsonIgnore]
        public string Password { get; set; }
    }
}
