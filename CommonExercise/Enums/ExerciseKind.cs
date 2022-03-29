using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Enums
{
    public enum ExerciseKind
    {
        [Display(Name = "Listen and remember")]
        ListenAndRemember = 1,
        [Display(Name = "Repeat")]
        Repeat = 2,
        [Display(Name = "Indicate")]
        Indicate = 3,
        [Display(Name = "Naming")]
        Naming = 4,
        [Display(Name = "Practise with me")]
        PractiseWithMe = 5,
        [Display(Name = "We count to ten")]
        CountToTen = 6,
        [Display(Name = "Repeat after each item")]
        RepeatAfterEachItem = 7,
        [Display(Name = "Arrange in turn")]
        ArrangeInTurn = 8,
        [Display(Name = "Days of the week")]
        DaysOfWeek = 9,
        [Display(Name = "Month")]
        Month = 10,
    }
}
