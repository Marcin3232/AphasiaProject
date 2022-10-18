using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models.User.Management
{
    public class AphasiaExerciseModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string ImageSrc { get; set; }
        public bool IsActive { get; set; }
       public string Name { get; set; }
    }
}
