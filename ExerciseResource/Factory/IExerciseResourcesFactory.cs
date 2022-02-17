namespace ExerciseResource.Factory
{
    public interface IExerciseResourcesFactory
    {
        object ExerciseResourceList(string idExerciseTask, bool random = false);
    }
}