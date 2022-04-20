using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.ExercisePanels.BasePanelFunc
{
    public static class SoundTaskHelper
    {
        private static string path => "/sound/";

        public static string GetSoundSrc(SoundSrc soundSrc) =>
           $"{path}{soundSrc.GetAttribute<DisplayAttribute>().Name}";
    }
}
