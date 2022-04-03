namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelIndicateModel
    {
        public string Word { get; set; }
        public string WordSound { get; set; }
        public string WordInstructionSound { get; set; }
        public string[] Picture { get; set; }
        public string Desctiption { get; set; }
        public string DescriptionSound { get; set; }
        public string QuestionSoundSrc { get; set; }
        public bool IsIndicate { get; set; } = false;
        public string ColorIndicate { get; set; } = " bcn ";
    }
}
