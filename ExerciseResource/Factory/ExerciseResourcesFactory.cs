using ExerciseResource.Models.Exercise02;
using ExerciseResource.Models.Exercise01;
using System.Collections.Generic;
using ExerciseResource.Models.Exercise05;
using ExerciseResource.Models.Exercise07;
using ExerciseResource.Models.Exercise33;
using ExerciseResource.Models.Exercise34;
using ExerciseResource.Models.Exercise08;
using ExerciseResource.Models.Exercise09;
using ExerciseResource.Models.Exercise10;
using ExerciseResource.Models.Exercise12;
using ExerciseResource.Models.Exercise42;
using ExerciseResource.Models.Exercise13;

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
                case "05":
                    return Exercise05ResourceList(random);
                case "07":
                    return Exercise07ResourceList(random);
                case "08":
                    return Exercise08ResourceList(random);
                case "09":
                    return Exercise09ResourceList(random);
                case "10":
                    return Exercise10ResourceList(random);
                case "12":
                    return Exercise12ResourceList(random);
                case "13":
                    return Exercise13ResourceList();
                case "33":
                    return Exercise33ResourceList(random);
                case "34":
                    return Exercise34ResourcesList(random);
                case "42":
                    return Exercise42ResourcesList(random);
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

        private List<Exercise05Resource> Exercise05ResourceList(bool random)
        {
            var model = new Exercise05ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise07Resource> Exercise07ResourceList(bool random)
        {
            var model = new Exercise07ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise08Resource> Exercise08ResourceList(bool random)
        {
            var model = new Exercise08ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise09Resource> Exercise09ResourceList(bool random)
        {
            var model = new Exercise09ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise10Resource> Exercise10ResourceList(bool random)
        {
            var model = new Exercise10ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise12Resource> Exercise12ResourceList(bool random)
        {
            var model = new Exercise12ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise13Resource> Exercise13ResourceList()
        {
            var model = new Exercise13ResourcesList();
            return model.GetValuesWithProperOrdes();
        }

        private List<Exercise33Resource> Exercise33ResourceList(bool random)
        {
            var model = new Exercise33ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise34Resource> Exercise34ResourcesList(bool random)
        {
            var model = new Exercise34ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }

        private List<Exercise42Resource> Exercise42ResourcesList(bool random)
        {
            var model = new Exercise42ResourcesList();
            return random ? model.GetRandomValues() : model.GetValues();
        }
    }
}
