using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelFilmModel
    {
        public Dictionary<int,List<string>> VideosSrc { get; set; }
        public List<string> FullSentenceSound { get; set; }
    }
}
