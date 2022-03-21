namespace AphasiaProject.Models.ResponseExercise
{
    public class ResponseExercisePhase
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int PhaseNameId { get; set; }
        public int KindId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string KindName { get; set; }
        public string KindDescription { get; set; }
        public int Kind { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public int Type { get; set; }
        public string PhaseDescription { get; set; }
        public string SoundSrc { get; set; }
        public int Repeat { get; set; }
        public bool IsSoundEveryStep { get; set; }
        public bool IsHelper { get; set; }
    }
}
