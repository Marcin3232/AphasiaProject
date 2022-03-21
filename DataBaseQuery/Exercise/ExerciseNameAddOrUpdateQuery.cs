using DataBaseQuery.ModelHelper;

namespace DataBaseQuery.Exercise
{
    public class ExerciseNameAddOrUpdateQuery
    {
        public static string InsertExerciseName() =>
            $"INSERT INTO \"ExerciseName\" (" +
            $"\"Id\", " +
            $"\"Name\", " +
            $"\"Description\", " +
            $"\"ImageSrc\", " +
            $"\"IdExerciseTask\") " +
            $"VALUES (" +
            $"@{nameof(ExerciseNameModelHelper.Id)}, " +
            $"@{nameof(ExerciseNameModelHelper.Name)}, " +
            $"@{nameof(ExerciseNameModelHelper.Description)}, " +
            $"@{nameof(ExerciseNameModelHelper.ImageSrc)}, " +
            $"@{nameof(ExerciseNameModelHelper.IdExerciseTask)}) " +
            $"RETURNING \"Id\"; ";

        public static string UpdateExerciseName() =>
            $"UPDATE \"ExerciseName\" " +
            $"SET" +
            $"\"Name\" = @{nameof(ExerciseNameModelHelper.Name)}, " +
            $"\"Description\" = @{nameof(ExerciseNameModelHelper.Description)}, " +
            $"\"ImageSrc\" = @{nameof(ExerciseNameModelHelper.ImageSrc)}, " +
            $"\"IdExerciseTask\" = @{nameof(ExerciseNameModelHelper.IdExerciseTask)} " +
            $"WHERE " +
            $"\"Id\" = @{nameof(ExerciseNameModelHelper.Id)} ";
    }
}
