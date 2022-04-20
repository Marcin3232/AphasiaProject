using CommonExercise.Enums;

namespace AphasiaClientApp.ExercisePanels.PanelMusicCore
{
    public class PanelMusicStyle
    {
        public static string SetMarginKey(int number) => 
            number > 0 ? "margin: 0 0 0 -2.3em;" : "";

        public static string SetPointer(int type) => (ExerciseType)type switch
        {
            ExerciseType.MusicListen => "",
            ExerciseType.MusicReapeat => "cursor: pointer;",
            _ => ""
        };
    }
}
