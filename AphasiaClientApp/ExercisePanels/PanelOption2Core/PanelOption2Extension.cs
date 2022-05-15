using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelOption2Core
{
    public static class PanelOption2Extension
    {
        public static bool OnShowDesc(ExercisePhase phase) => (ExerciseType)phase.Type switch
        {
            ExerciseType.ImageTextAndTextAroundDescWithImage => true,
            ExerciseType.ImageAndTextAroundDescWithImageNamingWithoutText => false,
            _ => true
        };

        public static string OnShowBorder(bool isShow) =>
            isShow ? "border-img" : "border-unvisible";
    }
}
