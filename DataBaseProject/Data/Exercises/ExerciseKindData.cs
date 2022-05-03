using DataBaseProject.Models.Exercise;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseKindData
    {
        private ExerciseKindNameData _exerciseKindNameData = new ExerciseKindNameData();

        public ExerciseKindModel GetKind(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseKindModel> GetFilled() => CreateList();

        private List<ExerciseKindModel> CreateList()
        {
            var temp = new List<ExerciseKindModel>();
            temp.Add(Create(1, _exerciseKindNameData.GetKindName(1)));
            temp.Add(Create(2, _exerciseKindNameData.GetKindName(2)));
            temp.Add(Create(3, _exerciseKindNameData.GetKindName(3)));
            temp.Add(Create(4, _exerciseKindNameData.GetKindName(4)));
            temp.Add(Create(5, _exerciseKindNameData.GetKindName(5)));
            temp.Add(Create(6, _exerciseKindNameData.GetKindName(6)));
            temp.Add(Create(7, _exerciseKindNameData.GetKindName(7)));
            temp.Add(Create(8, _exerciseKindNameData.GetKindName(8)));
            temp.Add(Create(9, _exerciseKindNameData.GetKindName(9)));
            temp.Add(Create(10, _exerciseKindNameData.GetKindName(10)));
            temp.Add(Create(11, _exerciseKindNameData.GetKindName(11)));
            temp.Add(Create(12, _exerciseKindNameData.GetKindName(12)));
            temp.Add(Create(13, _exerciseKindNameData.GetKindName(13)));
            temp.Add(Create(14, _exerciseKindNameData.GetKindName(14)));
            temp.Add(Create(15, _exerciseKindNameData.GetKindName(15)));
            temp.Add(Create(16, _exerciseKindNameData.GetKindName(16)));
            temp.Add(Create(17, _exerciseKindNameData.GetKindName(17)));
            temp.Add(Create(18, _exerciseKindNameData.GetKindName(18)));
            temp.Add(Create(19, _exerciseKindNameData.GetKindName(19)));
            temp.Add(Create(20, _exerciseKindNameData.GetKindName(20)));
            temp.Add(Create(21, _exerciseKindNameData.GetKindName(21)));
            temp.Add(Create(22, _exerciseKindNameData.GetKindName(22)));
            return temp;
        }

        private ExerciseKindModel Create(int id, ExerciseKindNameModel model) => new ExerciseKindModel
        {
            Id = id,
            ExerciseKindName = model,
        };
    }
}
