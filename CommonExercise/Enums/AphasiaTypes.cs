using System.ComponentModel.DataAnnotations;

namespace CommonExercise.Enums
{
    public enum AphasiaTypes
    {
        [Display(Name = "Afazja mieszana")]
        MixedAphasia = 1,
        [Display(Name = "Afazja ruchowa")]
        MovementAphasia = 2,
        [Display(Name = "Afazja czuciowa")]
        SensoryAphasia = 3
    }
}
