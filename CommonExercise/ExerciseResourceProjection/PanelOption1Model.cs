using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.ExerciseResourceProjection
{
    public class PanelOption1Model
    {
        public string Word { get; set; }
        public string WordSound { get; set; }
        public string Picture { get; set; }

        public static implicit operator List<object>(PanelOption1Model v)
        {
            throw new NotImplementedException();
        }
    }
}
