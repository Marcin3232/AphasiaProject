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
