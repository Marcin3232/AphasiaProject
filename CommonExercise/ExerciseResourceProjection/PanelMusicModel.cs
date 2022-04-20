using System.Collections.Generic;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelMusicModel
    {
        public List<SoundSrcExtension> SoundSrcList { get; set; }
        public string Category { get; set; }
    }

    public class SoundSrcExtension
    {
        public string SoundSrc { get; set; }
        public bool IsCorrect { get; set; }
        public int Order { get; set; } = 0;
        public string ColorBg { get; set; } = " m-bcw ";
    }
}
