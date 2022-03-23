using ExerciseResource.Models.Exercise02;
using ExerciseResource.Models.Exercise01;
using System.Collections.Generic;

namespace ExerciseResource.Factory
{
    public class ExerciseResourcesFactory : IExerciseResourcesFactory
    {
        public object ExerciseResourceList(string idExerciseTask, bool random = false)
        {

            switch (idExerciseTask)
            {
                case "01":
                    return Exercise01ResourceList(random);
                case "02":
                    return Exercise02ResourceList(random);
                default:
                    return null;
            }
        }

        private List<Exercise01Resource> Exercise01ResourceList(bool random)
        {
            var model = new Exercise01ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise02Resource> Exercise02ResourceList(bool random)
        {
            var model = new Exercise02ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

    }
}
