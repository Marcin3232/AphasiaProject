using DataBaseQuery.ModelHelper;

namespace DataBaseQuery.Exercise
{
    public class ExerciseAddOrUpdateQuery
    {
        public static string InsertExercise() =>
            $"INSERT INTO \"Exercise\" (" +
            $"\"Id\", " +
            $"\"ExerciseNameId\", " +
            $"\"IdUser\", " +
            $"\"IsActive\", " +
            $"\"AphasiaId\", " +
            $"\"Order\") " +
            $"VALUES (" +
            $"@{nameof(ExerciseModelHelper.Id)}, " +
            $"@{nameof(ExerciseModelHelper.ExerciseNameId)}, " +
            $"@{nameof(ExerciseModelHelper.IdUser)}, " +
            $"@{nameof(ExerciseModelHelper.IsActive)}, " +
            $"@{nameof(ExerciseModelHelper.AphasiaId)}, " +
            $"@{nameof(ExerciseModelHelper.Order)}) " +
            $"RETURNING \"Id\"; ";

        public static string UpdateExercise() =>
            $"UPDATE \"Exercise\" " +
            $"SET " +
            $"\"ExerciseNameId\" = @{nameof(ExerciseModelHelper.ExerciseNameId)}, " +
            $"\"IdUser\" = @{nameof(ExerciseModelHelper.IdUser)}, " +
            $"\"IsActive\" = @{nameof(ExerciseModelHelper.IsActive)}, " +
            $"\"AphasiaId\" = @{nameof(ExerciseModelHelper.AphasiaId)}, " +
            $"\"Order\" = @{nameof(ExerciseModelHelper.Order)} " +
            $"WHERE " +
            $"\"Id\" = @{nameof(ExerciseModelHelper.Id)} ";
    }
}
