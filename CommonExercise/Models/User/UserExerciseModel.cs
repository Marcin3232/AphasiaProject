using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public class UserExerciseModel
    {
             public int Id { get; set; }
            public int ExerciseId { get; set; }
            public int UserAphasiaId { get; set; }
            public bool IsActive { get; set; }  
    }
}
