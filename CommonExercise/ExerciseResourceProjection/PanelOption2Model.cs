using System.Collections.Generic;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelOption2Model
    {
        public string MainText { get; set; }
        public string PictureSrc { get; set; }
        public string MainSoundSrc { get; set; }
        public string MainSentenceSoundSrc { get; set; }
        public string MainInstructionSoundSrc { get; set; }
        public List<DescModel> DescModels { get; set; }

        public class DescModel
        {
            public string Text { get; set; }
            public string TextSoundSrc { get; set; }
            public string TextPictureSrc { get; set; }
            public bool IsShowBorder { get; set; } = false;

        }
    }
}
