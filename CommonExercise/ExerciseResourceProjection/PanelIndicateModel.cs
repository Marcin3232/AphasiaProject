namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelIndicateModel
    {
        public string Word { get; set; }
        public string WordSound { get; set; }
        public string WordInstructionSound { get; set; }
        public string[] Picture { get; set; }
        public bool IsIndicate { get; set; }= false;
        public string ColorIndicate { get; set; }= " bcn ";
    }
}
