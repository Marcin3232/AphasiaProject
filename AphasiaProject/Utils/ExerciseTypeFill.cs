using AphasiaProject.Models.DB.Exercises;
using AphasiaProject.Models.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace AphasiaProject.Utils
{
    public class ExerciseTypeFill
    {
        public static List<ExerciseTypeModel> GetFilled() => CreateList();

        protected static List<ExerciseTypeModel> CreateList()
        {
            var temp = new List<ExerciseTypeModel>();
            temp.Add(new ExerciseTypeModel() { Id = 1, ExerciseTypeName = ExerciseTypeNameFill.GetTypeName(1)}); ;
            return temp;
        }
    }
}
