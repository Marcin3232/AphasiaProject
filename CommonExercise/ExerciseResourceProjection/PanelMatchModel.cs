using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelMatchModel
    {
        public string Word { get; set; }
        public string WordSound { get; set; }
        public string WordInstructionSound { get; set; }
        public string Picture { get; set; }
        public string PictureSecond { get; set; }
        public string Desctiption { get; set; }
        public string DescriptionSound { get; set; }
        public string QuestionSoundSrc { get; set; }
        public bool IsMatch { get; set; } = false;
        public bool? IsCorrect { get; set; } = null;
        public string ColorIndicate { get; set; } = " bcn ";
    }
}
