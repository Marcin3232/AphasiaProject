using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Enums
{
    public enum ButtonEventType
    {
        [Display(Name ="button")]
        Button,
        [Display(Name ="submit")]
        Submit,
        [Display(Name ="reset")]
        Reset
    }
}
