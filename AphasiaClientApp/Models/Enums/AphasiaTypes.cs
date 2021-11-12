using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Enums
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
