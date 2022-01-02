using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise42
{
    public class Exercise42ResourcesList
    {
        private const string DirectoryName = "Exercise42";
        private List<Exercise42Resource> exercise42ResourceList = null;

        public Exercise42ResourcesList()
        {
            exercise42ResourceList = new List<Exercise42Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            foreach (string categoryPath in pathToFolders)
            {
                Exercise42Resource exercise42Resource = Exercise42Resource.CreateExercise42Resource(categoryPath);

                exercise42ResourceList.Add(exercise42Resource);
            }
        }

        public List<Exercise42Resource> GetValues()
        {
            return new List<Exercise42Resource>(exercise42ResourceList);
        }

        public List<Exercise42Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise42ResourceList);
        }
    }
}
