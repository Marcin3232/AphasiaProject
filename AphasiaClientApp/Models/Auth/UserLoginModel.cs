using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Auth
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Pole jest wymagane")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Password { get; set; }
    }
}
