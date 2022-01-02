using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise15
{
    public class Exercise15ResourcesList
    {
        private const string DirectoryName = "Exercise15";
        private List<Exercise15Resource> exercise15ResourceList = null;

        public Exercise15ResourcesList()
        {
            exercise15ResourceList = new List<Exercise15Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToDirectory = pathToFolders[i];
                var new15Resource = Exercise15Resource.CreateNewResource(pathToDirectory);

                exercise15ResourceList.Add(new15Resource);
            }
        }

        public List<Exercise15Resource> GetValues()
        {
            return new List<Exercise15Resource>(exercise15ResourceList);
        }

        public List<Exercise15Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise15ResourceList);
        }
    }
}
