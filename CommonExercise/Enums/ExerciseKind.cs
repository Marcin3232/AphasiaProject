using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Enums
{
    public enum  ExerciseKind
    {
        [Display(Name = "Listen and remember")]
        ListenAndRemember = 1,
        [Display(Name = "Repeat")]
        Repeat = 2,
        [Display(Name ="Indicate")]
        Indicate = 3,
        [Display(Name ="Naming")]
        Naming = 4, 

    }
}
