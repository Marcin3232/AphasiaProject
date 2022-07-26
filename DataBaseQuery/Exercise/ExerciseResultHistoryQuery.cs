using CommonExercise.Models;

namespace DataBaseQuery.Exercise;
public class ExerciseResultHistoryQuery
{
    public static string QueryGetExerciseResultHistory() =>
        $"SELECT " +
        $"erh.\"{nameof(ExerciseResultHistory.Id)}\", " +
        $"erh.\"{nameof(ExerciseResultHistory.Key)}\", " +
        $"erh.\"{nameof(ExerciseResultHistory.JsonValue)}\", " +
        $"erh.\"{nameof(ExerciseResultHistory.CreateTime)}\", " +
        $"erh.\"{nameof(ExerciseResultHistory.UpdateTime)}\"," +
        $"erh.\"{nameof(ExerciseResultHistory.IsDeleted)}\" " +
        $"FROM \"ExerciseResultHistory\" as erh ";

    public static string QueryGetLastExerciseResultHistory() =>
        $"{QueryGetExerciseResultHistory()} " +
        $"WHERE " +
        $"\"{nameof(ExerciseResultHistory.Key)}\" = @Key " +
        $"AND " +
        $"\"{nameof(ExerciseResultHistory.IsDeleted)}\" = false " +
        $"ORDER BY " +
        $"\"{nameof(ExerciseResultHistory.CreateTime)}\" desc " +
        $"LIMIT 1;";

    public static string QueryInsertExerciseResultHistory() =>
        $"INSERT INTO \"ExerciseResultHistory\" (" +
        $"\"{nameof(ExerciseResultHistory.Key)}\", " +
        $"\"{nameof(ExerciseResultHistory.JsonValue)}\", " +
        $"\"{nameof(ExerciseResultHistory.CreateTime)}\") " +
        $"VALUES (" +
        $"@{nameof(ExerciseResultHistory.Key)}, " +
        $"@{nameof(ExerciseResultHistory.JsonValue)}, " +
        $"@{nameof(ExerciseResultHistory.CreateTime)}) " +
        $"RETURNING \"Id\"; ";

    public static string QueryUpdateExerciseResultHistory() =>
        $"UPDATE \"ExerciseResultHistory\" " +
        $"SET " +
        $"\"{nameof(ExerciseResultHistory.JsonValue)}\" = @{nameof(ExerciseResultHistory.JsonValue)}, " +
        $"\"{nameof(ExerciseResultHistory.UpdateTime)}\" = @{nameof(ExerciseResultHistory.UpdateTime)} " +
        $"WHERE " +
        $"\"{nameof(ExerciseResultHistory.IsDeleted)}\" = false " +
        $"AND " +
        $"\"{nameof(ExerciseResultHistory.Key)}\" = @{nameof(ExerciseResultHistory.Key)} ";

    public static string QueryDeleteExerciseResultHisotry() =>
        $"UPDATE \"ExerciseResultHistory\" " +
        $"SET " +
        $"\"{nameof(ExerciseResultHistory.IsDeleted)}\" = true " +
        $"WHERE " +
        $"\"{nameof(ExerciseResultHistory.IsDeleted)}\" = false " +
        $"AND " +
        $"\"{nameof(ExerciseResultHistory.Key)}\" = @{nameof(ExerciseResultHistory.Key)} ";
}
