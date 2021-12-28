using AphasiaClientApp.Extensions;
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
        Back = 0,
        [Display(Name = "Close.svg")]
        Close = 1,
        [Display(Name = "Helper.svg")]
        Helper = 2,
        [Display(Name = "Next.svg")]
        Next = 3,
        [Display(Name = "Refresh.svg")]
        Refresh = 4,
        [Display(Name = "Sound.svg")]
        Sound = 5,
        [Display(Name = "RightNaviArrow.svg")]
        RightNaviArrow = 6,
        [Display(Name = "LeftNaviArrow.svg")]
        LeftNaviArrow = 7,
        [Display(Name = "setting-svgrepo-com.svg")]
        Settings = 8,
        [Display(Name = "Save.svg")]
        Save = 9,
        [Display(Name = "CheckCircle.svg")]
        CheckCircle = 10,
        [Display(Name = "CheckCheckbox.svg")]
        CheckedBox = 11,
        [Display(Name = "UncheckCheckbox.svg")]
        UncheckedBox = 12,
        [Display(Name = "ChartBar.svg")]
        ChartBar = 13,
        [Display(Name = "HeadMix.svg")]
        HeadMix = 14,
        [Display(Name = "HeadMoto.svg")]
        HeadMoto = 15,
        [Display(Name = "HeadSenso.svg")]
        HeadSenso = 16,
        [Display(Name = "Play.svg")]
        Play = 17,
    }

    public static class Path
    {
        public static string PathFile => @"resource/NaviImage/";
        public static string FullPathImage(NaviTypeImage typeImage) => PathFile + typeImage.GetAttribute<DisplayAttribute>().Name;
    }
}
