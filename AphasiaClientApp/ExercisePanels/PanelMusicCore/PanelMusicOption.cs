using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelMusicCore
{
    public class PanelMusicOption
    {
        public static bool IsRepeatMode(ExercisePhase phase) => (ExerciseType)phase.Type switch
        {
            ExerciseType.MusicListen => false,
            ExerciseType.MusicReapeat => true,
            _ => false
        };
    }
}
