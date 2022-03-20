﻿using DataBaseProject.Models.Exercise;

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
