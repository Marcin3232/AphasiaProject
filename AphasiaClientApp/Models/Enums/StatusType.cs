using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Models.Enums
{
    public enum  StatusType
    {
        [Display(Name = "Błąd")]
        Error = 0,
        [Display(Name = "Sukces")]
        Success = 1,
        [Display(Name = "Ostrzeżenie")]
        Warning = 2,
        [Display(Name = "Informacja")]
        Informational = 3,  
        [Display(Name ="Błąd krytyczny")]
        Critical = 4,
        [Display(Name ="Default")]
        Default = 5
    }
}
