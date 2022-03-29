using CommonExercise.Models.ExerciseResource;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelEnumerationModel : Exercise05_33_34Resource
    {
        public bool IsShow { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool? IsCorrect { get; set; } = null;
    }
}
