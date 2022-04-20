using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Models.Enums
{
    public enum SoundSrc
    {
        [Display(Name = "instructions/correct.mp3")]
        Correct =0,
        [Display(Name = "instructions/try_again.mp3")]
        TryAgain =1,
    }
}
