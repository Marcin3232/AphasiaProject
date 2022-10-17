using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public  class UserPhaseModel
    {

        public int ExercisePhaseId { get; set; }
        public int UserExerciseId { get; set; }
        public bool IsActive { get; set; }  
    }
}
    