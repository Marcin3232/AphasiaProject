using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Models.Auth
{
    public class UserRegistrationModel
    {
        internal bool IsSuccessfulRegistration;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Role { get; set; }
    }
}
    