namespace DataBaseQuery.ModelHelper
{
    public class ExercisePhaseModelHelper
    {
        public int Id { get; set; }
        public int PhaseNameId { get; set; }
        public int ExerciseId { get; set; }
        public int ExerciseKindId { get; set; }
        public int ExerciseTypeId { get; set; }
        public bool IsActive { get; set; }
        public int Repeat { get; set; }
        public bool IsSoundEveryStep { get; set; } = false;
        public bool IsHelper { get; set; } = false;
    }
}
