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
            };
    }
}
