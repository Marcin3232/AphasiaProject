using DataBaseProject.Models.Exercise;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseTypeNameData
    {
        public List<ExerciseTypeNameModel> GetFilled() => CreateList();
        public ExerciseTypeNameModel GetTypeName(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseTypeNameModel> CreateList()
        {
            var temp = new List<ExerciseTypeNameModel>();
            temp.Add(Create(1, 1, "Powtórz", "..."));
            temp.Add(Create(2, 2, "Wskaż obrazek", "..."));
            temp.Add(Create(3, 3, "Nazwij", "..."));
            return temp;
        }

        private ExerciseTypeNameModel Create(int id, int type, string name, string desc) => new ExerciseTypeNameModel()
        {
            Id = id,
            Type = type,
            Name = name,
            Description = desc
        };
    }
}
