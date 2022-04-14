using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelMatchCore
{
    public static class PanelModeService
    {
        public static PanelMode Get(ExercisePhase phase) => phase.Type switch
        {
            (int)ExerciseType.MatchImageToImage => PanelMode.Image,
            _ => PanelMode.Text
        };
    }
}
