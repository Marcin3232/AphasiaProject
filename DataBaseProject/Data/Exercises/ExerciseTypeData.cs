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
            temp.Add(Create(8, _exerciseTypeNameData.GetTypeName(8)));
            temp.Add(Create(9, _exerciseTypeNameData.GetTypeName(9)));
            temp.Add(Create(10, _exerciseTypeNameData.GetTypeName(10)));
            temp.Add(Create(11, _exerciseTypeNameData.GetTypeName(11)));
            temp.Add(Create(12, _exerciseTypeNameData.GetTypeName(12)));
            temp.Add(Create(13, _exerciseTypeNameData.GetTypeName(13)));
            temp.Add(Create(14, _exerciseTypeNameData.GetTypeName(14)));
            temp.Add(Create(15, _exerciseTypeNameData.GetTypeName(15)));
            temp.Add(Create(16, _exerciseTypeNameData.GetTypeName(16)));
            temp.Add(Create(17, _exerciseTypeNameData.GetTypeName(17)));
            temp.Add(Create(18, _exerciseTypeNameData.GetTypeName(18)));
            temp.Add(Create(19, _exerciseTypeNameData.GetTypeName(19)));
            temp.Add(Create(20, _exerciseTypeNameData.GetTypeName(20)));
            temp.Add(Create(21, _exerciseTypeNameData.GetTypeName(21)));
            temp.Add(Create(22, _exerciseTypeNameData.GetTypeName(22)));
            temp.Add(Create(23, _exerciseTypeNameData.GetTypeName(23)));
            return temp;
        }

        private ExerciseTypeModel Create(int id, ExerciseTypeNameModel model) => new ExerciseTypeModel()
        {
            Id = id,
            ExerciseTypeName = model
        };
    }
}
