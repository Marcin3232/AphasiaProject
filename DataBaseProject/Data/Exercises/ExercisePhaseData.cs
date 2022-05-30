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
            temp.Add(Create(21, _exercisePhaseNameData.GetPhaseName(1), 7, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(22, _exercisePhaseNameData.GetPhaseName(2), 7, _exerciseKindData.GetKind(13), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(23, _exercisePhaseNameData.GetPhaseName(3), 7, _exerciseKindData.GetKind(3), _exerciseTypeData.GetType(2), true, 1, true, true));
            temp.Add(Create(24, _exercisePhaseNameData.GetPhaseName(4), 7, _exerciseKindData.GetKind(14), _exerciseTypeData.GetType(3), true, 1, false, false));
            temp.Add(Create(25, _exercisePhaseNameData.GetPhaseName(5), 7, _exerciseKindData.GetKind(15), _exerciseTypeData.GetType(8), true, 1, true, true));
            temp.Add(Create(26, _exercisePhaseNameData.GetPhaseName(1), 10, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(27, _exercisePhaseNameData.GetPhaseName(2), 10, _exerciseKindData.GetKind(2), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(28, _exercisePhaseNameData.GetPhaseName(3), 10, _exerciseKindData.GetKind(3), _exerciseTypeData.GetType(2), true, 1, true, true));
            temp.Add(Create(29, _exercisePhaseNameData.GetPhaseName(4), 10, _exerciseKindData.GetKind(16), _exerciseTypeData.GetType(9), true, 1, true, true));
            temp.Add(Create(30, _exercisePhaseNameData.GetPhaseName(1), 11, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(10), true, 1, false, false));
            temp.Add(Create(31, _exercisePhaseNameData.GetPhaseName(2), 11, _exerciseKindData.GetKind(2), _exerciseTypeData.GetType(11), true, 1, false, false));
            temp.Add(Create(32, _exercisePhaseNameData.GetPhaseName(1), 8, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(12), true, 1, false, false));
            temp.Add(Create(33, _exercisePhaseNameData.GetPhaseName(2), 8, _exerciseKindData.GetKind(14), _exerciseTypeData.GetType(13), true, 1, false, false));
            temp.Add(Create(34, _exercisePhaseNameData.GetPhaseName(3), 8, _exerciseKindData.GetKind(17), _exerciseTypeData.GetType(2), true, 1, true, true));
            temp.Add(Create(35, _exercisePhaseNameData.GetPhaseName(4), 8, _exerciseKindData.GetKind(18), _exerciseTypeData.GetType(14), true, 1, false, false));
            temp.Add(Create(36, _exercisePhaseNameData.GetPhaseName(1), 12, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(37, _exercisePhaseNameData.GetPhaseName(2), 12, _exerciseKindData.GetKind(19), _exerciseTypeData.GetType(6), true, 1, false, false));
            temp.Add(Create(38, _exercisePhaseNameData.GetPhaseName(3), 12, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(13), true, 1, false, false));
            temp.Add(Create(39, _exercisePhaseNameData.GetPhaseName(5), 12, _exerciseKindData.GetKind(20), _exerciseTypeData.GetType(15), true, 1, true, true));
            temp.Add(Create(40, _exercisePhaseNameData.GetPhaseName(4), 12, _exerciseKindData.GetKind(21), _exerciseTypeData.GetType(16), true, 1, true, true));
            temp.Add(Create(41, _exercisePhaseNameData.GetPhaseName(1), 13, _exerciseKindData.GetKind(22), _exerciseTypeData.GetType(17), true, 1, true, true));
            temp.Add(Create(42, _exercisePhaseNameData.GetPhaseName(3), 13, _exerciseKindData.GetKind(22), _exerciseTypeData.GetType(19), true, 1, true, true));
            temp.Add(Create(43, _exercisePhaseNameData.GetPhaseName(4), 13, _exerciseKindData.GetKind(22), _exerciseTypeData.GetType(20), true, 1, true, true));
            temp.Add(Create(44, _exercisePhaseNameData.GetPhaseName(1), 14, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(22), true, 1, false, false));
            temp.Add(Create(45, _exercisePhaseNameData.GetPhaseName(2), 14, _exerciseKindData.GetKind(23), _exerciseTypeData.GetType(22), true, 1, false, false));
            temp.Add(Create(46, _exercisePhaseNameData.GetPhaseName(3), 14, _exerciseKindData.GetKind(24), _exerciseTypeData.GetType(23), true, 1, false, false));
            temp.Add(Create(47, _exercisePhaseNameData.GetPhaseName(1), 15, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(48, _exercisePhaseNameData.GetPhaseName(2), 15, _exerciseKindData.GetKind(2), _exerciseTypeData.GetType(1), true, 1, false, false));
            temp.Add(Create(49, _exercisePhaseNameData.GetPhaseName(3), 15, _exerciseKindData.GetKind(25), _exerciseTypeData.GetType(24), true, 1, true, true));
            temp.Add(Create(50, _exercisePhaseNameData.GetPhaseName(4), 15, _exerciseKindData.GetKind(26), _exerciseTypeData.GetType(25), true, 1, true, true));
            temp.Add(Create(51, _exercisePhaseNameData.GetPhaseName(1), 16, _exerciseKindData.GetKind(1), _exerciseTypeData.GetType(26), true, 1, false, false));
            temp.Add(Create(52, _exercisePhaseNameData.GetPhaseName(2), 16, _exerciseKindData.GetKind(2), _exerciseTypeData.GetType(26), true, 1, false, false));
            temp.Add(Create(53, _exercisePhaseNameData.GetPhaseName(3), 16, _exerciseKindData.GetKind(27), _exerciseTypeData.GetType(27), true, 1, true, true));
            temp.Add(Create(54, _exercisePhaseNameData.GetPhaseName(5), 16, _exerciseKindData.GetKind(28), _exerciseTypeData.GetType(28), true, 1, true, true));
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
