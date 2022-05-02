using CommonExercise.Enums;
using System.Collections.Generic;

namespace CommonExercise.ExercisePanel
{
    public class ExercisePanelManager
    {
        public static ExercisePanelOption GetPanel(ExerciseType type) =>
            Dictionary().TryGetValue(type, out var result) ? result : default(ExercisePanelOption);

        private static Dictionary<ExerciseType, ExercisePanelOption> Dictionary() =>
            new Dictionary<ExerciseType, ExercisePanelOption>()
            {
                {ExerciseType.SingleImageTextRepeat,ExercisePanelOption.PanelOption1 },
                {ExerciseType.Naming,ExercisePanelOption.PanelOption1 },
                {ExerciseType.IndicateImage,ExercisePanelOption.PanelIndicate },
                {ExerciseType.Films,ExercisePanelOption.PanelFilm },
                {ExerciseType.Enumeration,ExercisePanelOption.PanelEnumeration},
                {ExerciseType.EnumerationRepeat,ExercisePanelOption.PanelEnumeration },
                {ExerciseType.ArrangeInTurn,ExercisePanelOption.PanelEnumeration },
                {ExerciseType.MatchCaptionToPicture,ExercisePanelOption.PanelMatch },
                {ExerciseType.MatchImageToImage,ExercisePanelOption.PanelMatch },
                {ExerciseType.MusicReapeat,ExercisePanelOption.PanelMusic },
                {ExerciseType.MusicListen,ExercisePanelOption.PanelMusic },
                {ExerciseType.SingleImageThreeSoundTextRepeat,ExercisePanelOption.PanelOption1},
                {ExerciseType.SingleImageTwoSoundWithBreakTextRepeat,ExercisePanelOption.PanelOption1},
                {ExerciseType.NamingWithSound,ExercisePanelOption.PanelOption1},
                {ExerciseType.MatchCaptionToPictureCaptionUnderMode,ExercisePanelOption.PanelMatch},
                {ExerciseType.MatchCaptionToPictureWithDescSound, ExercisePanelOption.PanelMatch },
            };
    }
}
