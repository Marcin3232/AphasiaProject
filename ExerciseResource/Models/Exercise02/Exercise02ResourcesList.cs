using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise02
{
    public class Exercise02ResourcesList
    {
        private const string DirectoryName = "Exercise02";
        private List<Exercise02Resource> exercise02ResourceList = null;

        public Exercise02ResourcesList()
        {
            exercise02ResourceList = new List<Exercise02Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            foreach (string folderPath in pathToFolders)
            {
                Exercise02Resource exercise02Resource = Exercise02Resource.CreateExercise02Resource(folderPath);

                exercise02ResourceList.Add(exercise02Resource);
            }
        }

        public List<Exercise02Resource> GetValues()
        {
            return new List<Exercise02Resource>(exercise02ResourceList);
        }

        public List<Exercise02Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues<Exercise02Resource>(exercise02ResourceList);
        }
    }
}
