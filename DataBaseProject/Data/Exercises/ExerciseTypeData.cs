using DataBaseProject.Models.Exercise;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseTypeData
    {
        public static List<ExerciseTypeModel> GetFilled() => CreateList();

        protected static List<ExerciseTypeModel> CreateList()
        {
            var temp = new List<ExerciseTypeModel>();
            temp.Add(new ExerciseTypeModel() { Id = 1, ExerciseTypeName = ExerciseTypeNameData.GetTypeName(1) }); ;
            return temp;
        }
    }
}
