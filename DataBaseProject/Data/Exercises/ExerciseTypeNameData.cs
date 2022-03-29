using CommonExercise.Enums;
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
            temp.Add(Create(1, (int)ExerciseType.SingleImageTextRepeat, "Powtórz", "..."));
            temp.Add(Create(2, (int)ExerciseType.IndicateImage, "Wskaż obrazek", "..."));
            temp.Add(Create(3, (int)ExerciseType.Naming, "Nazwij", "..."));
            temp.Add(Create(4, (int)ExerciseType.Films, "Film", "..."));
            temp.Add(Create(5, (int)ExerciseType.Enumeration, "Wyliczanie", "..."));
            temp.Add(Create(6, (int)ExerciseType.EnumerationRepeat, "Powtórz po kolei", "..."));
            temp.Add(Create(7, (int)ExerciseType.ArrangeInTurn, "Ułóż po kolei", "..."));
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
