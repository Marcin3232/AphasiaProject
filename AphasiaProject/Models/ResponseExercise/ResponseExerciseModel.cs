using AphasiaProject.Models.Exercises;
using System.Collections.Generic;

namespace AphasiaProject.Models.ResponseExercise
{
    public class ResponseExerciseModel
    {
        public ResponseExerciseInformation ExerciseInformation { get; set; }
        public List<ResponseExercisePhase> Phases { get; set; }
        public object ExerciseResource { get; set; }
    }
}
