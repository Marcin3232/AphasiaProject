using CommonExercise.Enums;
using CommonExercise.Models;

namespace AphasiaClientApp.ExercisePanels.PanelFindPairGameCore
{
    public static class PanelTile
    {
        public static int GetCount(ExercisePhase phase) => phase.Type switch
        {
            (int)ExerciseType.FindPairLevelOne => 8,
            (int)ExerciseType.FindPairLevelTwo => 8,
            (int)ExerciseType.FindPairLevelThree => 12,
            (int)ExerciseType.FindPairLevelFour => 16,
            (int)ExerciseType.FindPairLevelFive => 16,
            _=> 4
        };

        public static string SetTileInRow(int count) => count switch
        {
            6 => "4",
            8 => "3",
            10 => "3",
            12 => "2",
            14=> "2",
            16 => "2",
            _ => ""
        };
    }
}
