using DataBaseProject.Models.Exercise;

namespace DataBaseProject.Data.Exercises
{
    public class ExercisePhaseData
    {
        private ExercisePhaseNameData _exercisePhaseNameData = new ExercisePhaseNameData();
        private ExerciseKindData _exerciseKindData = new ExerciseKindData();
        private ExerciseTypeData _exerciseTypeData = new ExerciseTypeData();

        public List<ExercisePhaseModel> GetPhases(int id) => GetFilled().Where(x => x.ExerciseId == id).ToList();
        public List<ExercisePhaseModel> GetFilled() => CreateList();

        private List<ExercisePhaseModel> CreateList()
        {
            var temp = new List<ExercisePhaseModel>();
            temp.Add(Create(1, _exercisePhaseNameData.GetPhaseName(1), 1, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 3, false, false));
            temp.Add(Create(2, _exercisePhaseNameData.GetPhaseName(2), 1, _exerciseKindData.GetKind(2), _exerciseTypeData.GetType(1), true, 3, false, false));
            temp.Add(Create(3, _exercisePhaseNameData.GetPhaseName(3), 1, _exerciseKindData.GetKind(3), _exerciseTypeData.GetType(2), true, 3, true, true));
            temp.Add(Create(4, _exercisePhaseNameData.GetPhaseName(4), 1, _exerciseKindData.GetKind(4), _exerciseTypeData.GetType(3), true, 3, false, false));
            temp.Add(Create(5, _exercisePhaseNameData.GetPhaseName(1), 2, _exerciseKindData.GetKind(5), _exerciseTypeData.GetType(4), true, 1, true, false));
            temp.Add(Create(6, _exercisePhaseNameData.GetPhaseName(2), 2, _exerciseKindData.GetKind(5), _exerciseTypeData.GetType(4), true, 1, true, false));
            temp.Add(Create(7, _exercisePhaseNameData.GetPhaseName(4), 2, _exerciseKindData.GetKind(5), _exerciseTypeData.GetType(4), true, 1, true, false));
            temp.Add(Create(8, _exercisePhaseNameData.GetPhaseName(1), 3, _exerciseKindData.GetKind(6), _exerciseTypeData.GetType(5), true, 1, false, false));
            temp.Add(Create(9, _exercisePhaseNameData.GetPhaseName(2), 3, _exerciseKindData.GetKind(7), _exerciseTypeData.GetType(6), true, 1, false, false));
            temp.Add(Create(10, _exercisePhaseNameData.GetPhaseName(3), 3, _exerciseKindData.GetKind(8), _exerciseTypeData.GetType(7), true, 1, false, true));
            temp.Add(Create(11, _exercisePhaseNameData.GetPhaseName(1), 4, _exerciseKindData.GetKind(9), _exerciseTypeData.GetType(5), true, 1, false, false));
            temp.Add(Create(12, _exercisePhaseNameData.GetPhaseName(2), 4, _exerciseKindData.GetKind(7), _exerciseTypeData.GetType(6), true, 1, false, false));
            temp.Add(Create(13, _exercisePhaseNameData.GetPhaseName(3), 4, _exerciseKindData.GetKind(8), _exerciseTypeData.GetType(7), true, 1, false, true));
            temp.Add(Create(14, _exercisePhaseNameData.GetPhaseName(1), 5, _exerciseKindData.GetKind(10), _exerciseTypeData.GetType(5), true, 1, false, false));
            temp.Add(Create(15, _exercisePhaseNameData.GetPhaseName(2), 5, _exerciseKindData.GetKind(7), _exerciseTypeData.GetType(6), true, 1, false, false));
            temp.Add(Create(16, _exercisePhaseNameData.GetPhaseName(3), 5, _exerciseKindData.GetKind(8), _exerciseTypeData.GetType(7), true, 1, false, true));
            temp.Add(Create(17, _exercisePhaseNameData.GetPhaseName(1), 6, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(18, _exercisePhaseNameData.GetPhaseName(2), 6, _exerciseKindData.GetKind(11), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(19, _exercisePhaseNameData.GetPhaseName(3), 6, _exerciseKindData.GetKind(3), _exerciseTypeData.GetType(2), true, 1, false, true));
            temp.Add(Create(20, _exercisePhaseNameData.GetPhaseName(5), 6, _exerciseKindData.GetKind(12), _exerciseTypeData.GetType(2), true, 1, false, true));
            return temp;
        }

        private ExercisePhaseModel Create(int id, ExercisePhaseNameModel namePhase, int exerciseId,
            ExerciseKindModel kind, ExerciseTypeModel type, bool isActive, int repeat = 1, bool isSoundEverystep = false,
            bool isHelper = false)
            => new ExercisePhaseModel()
            {
                Id = id,
                PhaseName = namePhase,
                ExerciseId = exerciseId,
                ExerciseKind = kind,
                ExerciseType = type,
                IsActive = isActive,
                Repeat = repeat,
                IsSoundEveryStep = isSoundEverystep,
                IsHelper = isHelper
            };
    }
}
