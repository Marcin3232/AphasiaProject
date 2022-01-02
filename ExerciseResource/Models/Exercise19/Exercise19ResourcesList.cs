using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise19
{
    public class Exercise19ResourcesList
    {
        private const string DirectoryName = "Exercise19";
        private List<Exercise19Resource> exercise19ResourceList = null;

        public Exercise19ResourcesList()
        {
            exercise19ResourceList = new List<Exercise19Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise19Resource.CreateNewResource(pathToFolderSentence);

                exercise19ResourceList.Add(newResource);
            }
        }

        public List<Exercise19Resource> GetValues()
        {
            return new List<Exercise19Resource>(exercise19ResourceList);
        }

        public List<Exercise19Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise19ResourceList);
        }
    }
}
