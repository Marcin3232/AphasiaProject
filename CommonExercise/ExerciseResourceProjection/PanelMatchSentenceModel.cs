
using System.Collections.Generic;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelMatchSentenceModel
    {
        public string PicturesSrcs { get; set; }
        public Expression Main { get; set; }
        public Expression Wrong { get; set; }
        public List<Expression> Question { get; set; }
        public List<Expression> Answer { get; set; }
        public List<Expression> Selected { get; set; }
        public List<string> Part { get; set; }

        public class Expression
        {
            public string Text { get; set; }
            public string SoundSrc { get; set; }
            public int Id { get; set; }
            public bool? IsCorrect { get; set; } = null;
            public bool IsSelected { get; set; } = false;
            public bool IsShow { get; set; }
        }
    }
}
