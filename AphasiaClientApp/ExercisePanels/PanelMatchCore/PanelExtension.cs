using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelMatchCore
{
    public static class PanelExtension
    {
        public static bool IsPlayName(ExercisePhase phase) => PanelModeService.Get(phase) switch
        {

            PanelMode.Text => true,
            PanelMode.TextUnder => true,
            PanelMode.Image => false,
            _ => false
        };

        public static string SetColPosition(ExercisePhase phase, bool isMainImage = false) => PanelModeService.GetPosition(phase) switch
        {
            MainImage.Left => isMainImage ? " order-1 " : " order-2",
            _ => ""
        };
    }
}
