using CommonExercise.Enums;

namespace AphasiaProject.Models.Exercises
{
    public class AvaibleBaseExercise
    {
        public int Id { get; set; }
        public string IdExerciseTask { get; set; }
        public AphasiaTypes AphasiaType { get; set; }
    }
}
