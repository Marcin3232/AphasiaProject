namespace AphasiaProject.Models.ResponseExercise
{
    public class ResponseExerciseInformation
    {
        public int ExerciseId { get; set; }
        public int ExerciseNameId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public string ExerciseTaskId { get; set; }
    }
}
