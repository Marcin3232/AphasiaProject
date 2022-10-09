

using CommonExercise.Enums.Keys;

namespace Extensions.Exercise;

public class KeyExtension
{
    public static string Generate(int id, int idUser, ExerciseKey key) => $"id:{id}|idUser:{idUser}|key:{key}";
}
