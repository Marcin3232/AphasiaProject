using DataBaseQuery.ModelHelper;

namespace DataBaseQuery.Exercise
{
    public class ExercisePhaseAddOrUpdateQuery
    {
        public static string InsertExercisePhase() =>
            $"INSERT INTO \"ExercisePhase\" (" +
            $"\"Id\", " +
            $"\"PhaseNameId\", " +
            $"\"ExerciseId\", " +
            $"\"IsActive\", " +
            $"\"ExerciseKindId\", " +
            $"\"ExerciseTypeId\", " +
            $"\"Repeat\", " +
            $"\"IsSoundEveryStep\", " +
            $"\"IsHelper\") " +
            $"VALUES (" +
            $"@{nameof(ExercisePhaseModelHelper.Id)}, " +
            $"@{nameof(ExercisePhaseModelHelper.PhaseNameId)}, " +
            $"@{nameof(ExercisePhaseModelHelper.ExerciseId)}, " +
            $"@{nameof(ExercisePhaseModelHelper.IsActive)}, " +
            $"@{nameof(ExercisePhaseModelHelper.ExerciseKindId)}, " +
            $"@{nameof(ExercisePhaseModelHelper.ExerciseTypeId)}, " +
            $"@{nameof(ExercisePhaseModelHelper.Repeat)}, " +
            $"@{nameof(ExercisePhaseModelHelper.IsSoundEveryStep)}, " +
            $"@{nameof(ExercisePhaseModelHelper.IsHelper)}) " +
            $"RETURNING \"Id\"; ";

        public static string UpdateExercisePhase() =>
            $"UPDATE \"ExercisePhase\" " +
            $"SET " +
            $"\"PhaseNameId\" = @{nameof(ExercisePhaseModelHelper.PhaseNameId)}, " +
            $"\"ExerciseId\" = @{nameof(ExercisePhaseModelHelper.ExerciseId)}, " +
            $"\"IsActive\" = @{nameof(ExercisePhaseModelHelper.IsActive)}, " +
            $"\"ExerciseKindId\" = @{nameof(ExercisePhaseModelHelper.ExerciseKindId)}, " +
            $"\"ExerciseTypeId\" = @{nameof(ExercisePhaseModelHelper.ExerciseTypeId)}, " +
            $"\"Repeat\" = @{nameof(ExercisePhaseModelHelper.Repeat)}, " +
            $"\"IsSoundEveryStep\" = @{nameof(ExercisePhaseModelHelper.IsSoundEveryStep)}, " +
            $"\"IsHelper\" = @{nameof(ExercisePhaseModelHelper.IsHelper)} " +
            $"WHERE " +
            $"\"Id\" = @{nameof(ExercisePhaseModelHelper.Id)} ";
    }
}
