using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Enums
{
    public enum NaviTypeImage
    {
        [Display(Name = "Back.svg")]
        Back,
        [Display(Name = "Close.svg")]
        Close,
        [Display(Name = "Helper.svg")]
        Helper,
        [Display(Name = "Next.svg")]
        Next,
        [Display(Name = "Refresh.svg")]
        Refresh,
        [Display(Name = "Sound.svg")]
        Sound
    }

    public static class Path
    {
        public static string PathFile => @"resource/NaviImage/";
    }
}
