using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models.User.Management
{
    public class UserExercisePhaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
