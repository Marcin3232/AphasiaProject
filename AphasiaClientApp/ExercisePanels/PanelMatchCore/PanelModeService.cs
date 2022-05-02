using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelMatchCore
{
    public static class PanelModeService
    {
        public static PanelMode Get(ExercisePhase phase) => phase.Type switch
        {
            (int)ExerciseType.MatchImageToImage => PanelMode.Image,
            (int)ExerciseType.MatchCaptionToPictureCaptionUnderMode=> PanelMode.TextUnder,
            _ => PanelMode.Text
        };

        public static PanelTaskMode GetTask(ExercisePhase phase)=> phase.Type switch
        {
            (int)ExerciseType.MatchImageToImage => PanelTaskMode.HelperTask,
            (int)ExerciseType.MatchCaptionToPictureCaptionUnderMode => PanelTaskMode.EmptyTask,
            (int)ExerciseType.MatchCaptionToPictureWithDescSound=> PanelTaskMode.WorkTask,
            _ => PanelTaskMode.HelperTask
        };

        public static MainImage GetPosition(ExercisePhase phase) => phase.Type switch
        {
            (int)ExerciseType.MatchCaptionToPictureWithDescSound => MainImage.Left,
            _ => MainImage.Right,
        };
    }
}
