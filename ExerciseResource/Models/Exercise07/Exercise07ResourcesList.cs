using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise07
{
    public class Exercise07ResourcesList
    {
        private const string DirectoryName = "Exercise07";
        private List<Exercise07Resource> exercise07ResourceList = null;

        public Exercise07ResourcesList()
        {
            exercise07ResourceList = new List<Exercise07Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise07Resource.CreateNewResource(pathToFolderSentence);

                exercise07ResourceList.Add(newResource);
            }
        }

        public List<Exercise07Resource> GetValues()
        {
            return new List<Exercise07Resource>(exercise07ResourceList);
        }

        public List<Exercise07Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues<Exercise07Resource>(exercise07ResourceList);
        }
    }
}
