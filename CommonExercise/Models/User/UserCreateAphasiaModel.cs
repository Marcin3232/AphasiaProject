using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models.User
{
    public class UserCreateAphasiaModel
    {
       public int IdUser { get; set; } 
       public int AphasiaId { get; set; }   

        public bool IsActive { get; set; }
    }
}
