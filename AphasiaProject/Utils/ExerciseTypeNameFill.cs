using AphasiaProject.Models.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace AphasiaProject.Utils
{
    public class ExerciseTypeNameFill
    {
        public static List<ExerciseTypeNameModel> GetFilled() => CreateList();
        public static ExerciseTypeNameModel GetTypeName(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private static List<ExerciseTypeNameModel> CreateList()
        {
            var temp = new List<ExerciseTypeNameModel>();
            temp.Add(new ExerciseTypeNameModel() { Id = 1, Type = 1, Name = "Powtórz", Description = "..." });
            return temp;
        }
    }
}
