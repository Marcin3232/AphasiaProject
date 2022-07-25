using CommonExercise.Models;

namespace DataBaseQuery.Exercise;
public class ExerciseResultHistoryQuery
{
    public static string QueryGetExerciseResultHistory() =>
        $"SELECT " +
        $"erh.\"Id\" as {nameof(ExerciseResultHistory.Id)}, " +
        $"erh.\"Key\" as {nameof(ExerciseResultHistory.Key)}, " +
        $"erh.\"JsonValue\" as {nameof(ExerciseResultHistory.JsonValue)}, " +
        $"erh.\"CreateTime\" as {nameof(ExerciseResultHistory.CreateTime)} " +
        $"FROM \"ExerciseResultHistory\" as erh ";

    public static string QueryGetLastExerciseResultHistory() =>
        $"{QueryGetExerciseResultHistory()} " +
        $"WHERE " +
        $"\"Key\" = @Key " +
        $"ORDER BY " +
        $"{nameof(ExerciseResultHistory.CreateTime)} desc " +
        $"LIMIT 1;";

    public static string QueryInsertExerciseResultHistory() =>
        $"INSERT INTO \"ExerciseResultHistory\" (" +
        $"\"Key\", " +
        $"\"JsonValue\", " +
        $"\"CreateTime\") " +
        $"VALUES (" +
        $"@{nameof(ExerciseResultHistory.Key)}, " +
        $"@{nameof(ExerciseResultHistory.JsonValue)}, " +
        $"@{nameof(ExerciseResultHistory.CreateTime)}) " +
        $"RETURNING \"Id\"; ";
}
