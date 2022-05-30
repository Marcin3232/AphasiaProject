using DataBaseProject.Models.Exercise;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseData
    {
        private ExerciseNameData _exerciseNameData = new ExerciseNameData();

        public List<ExerciseModel> GetFilled() => CreateList();

        private List<ExerciseModel> CreateList()
        {
            var temp = new List<ExerciseModel>();
            temp.Add(Create(1, _exerciseNameData.GetName("01"), 0, true, null, 0));
            temp.Add(Create(2, _exerciseNameData.GetName("02"), 0, true, null, 0));
            temp.Add(Create(3, _exerciseNameData.GetName("05"), 0, true, null, 0));
            temp.Add(Create(4, _exerciseNameData.GetName("33"), 0, true, null, 0));
            temp.Add(Create(5, _exerciseNameData.GetName("34"), 0, true, null, 0));
            temp.Add(Create(6, _exerciseNameData.GetName("07"), 0, true, null, 0));
            temp.Add(Create(7, _exerciseNameData.GetName("08"), 0, true, null, 0));
            temp.Add(Create(8, _exerciseNameData.GetName("09"), 0, true, null, 0));
            //temp.Add(Create(9, _exerciseNameData.GetName("10"), 0, true, null, 0));
            temp.Add(Create(10, _exerciseNameData.GetName("12"), 0, true, null, 0));
            temp.Add(Create(11, _exerciseNameData.GetName("42"), 0, true, null, 0));
            temp.Add(Create(12, _exerciseNameData.GetName("13"), 0, true, null, 0));
            temp.Add(Create(13, _exerciseNameData.GetName("24"), 0, true, null, 0));
            temp.Add(Create(14, _exerciseNameData.GetName("14"), 0, true, null, 0));
            temp.Add(Create(15, _exerciseNameData.GetName("15"), 0, true, null, 0));
            temp.Add(Create(16, _exerciseNameData.GetName("16"), 0, true, null, 0));
            return temp;
        }

        private ExerciseModel Create(int id, ExerciseNameModel exerciseName, int idUser,
            bool isActive, AphasiaModel aphasiaModel, int order) => new ExerciseModel()
            {
                Id = id,
                ExerciseName = exerciseName,
                IdUser = idUser,
                IsActive = isActive,
                Aphasia = aphasiaModel,
                Order = order
            };
    }
}
