using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Models.Enums
{
    public enum SoundSrc
    {
        [Display(Name = "instructions/correct.mp3")]
        Correct =0,
        [Display(Name = "instructions/try_again.mp3")]
        TryAgain =1,
        [Display(Name = "instructions/bu.mp3")]
        Bu = 2,
        [Display(Name = "instructions/blik.mp3")]
        Blik = 3,
    }
}
