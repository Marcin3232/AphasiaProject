using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Models.MainPanel
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string PasswordRepeat { get; set; }
    }
}
