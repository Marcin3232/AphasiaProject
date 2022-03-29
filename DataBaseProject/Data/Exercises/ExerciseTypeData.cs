using DataBaseProject.Models.Exercise;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseTypeData
    {
        private ExerciseTypeNameData _exerciseTypeNameData = new ExerciseTypeNameData();

        public ExerciseTypeModel GetType(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseTypeModel> GetFilled() => CreateList();

        private List<ExerciseTypeModel> CreateList()
        {
            var temp = new List<ExerciseTypeModel>();
            temp.Add(Create(1, _exerciseTypeNameData.GetTypeName(1)));
            temp.Add(Create(2, _exerciseTypeNameData.GetTypeName(2)));
            temp.Add(Create(3, _exerciseTypeNameData.GetTypeName(3)));
            temp.Add(Create(4, _exerciseTypeNameData.GetTypeName(4)));
            temp.Add(Create(5, _exerciseTypeNameData.GetTypeName(5)));
            temp.Add(Create(6, _exerciseTypeNameData.GetTypeName(6)));
            temp.Add(Create(7, _exerciseTypeNameData.GetTypeName(7)));
            return temp;
        }

        private ExerciseTypeModel Create(int id, ExerciseTypeNameModel model) => new ExerciseTypeModel()
        {
            Id = id,
            ExerciseTypeName = model
        };
    }
}
