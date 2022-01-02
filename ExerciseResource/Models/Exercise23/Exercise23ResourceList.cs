using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise23
{
    public class Exercise23ResourcesList
    {
        private const string DirectoryName = "Exercise23";
        private List<Exercise23Resource> exercise23ResourceList = null;

        public Exercise23ResourcesList()
        {
            exercise23ResourceList = new List<Exercise23Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise23Resource.CreateNewResource(pathToFolderSentence);

                exercise23ResourceList.Add(newResource);
            }
        }

        public List<Exercise23Resource> GetValues()
        {
            return new List<Exercise23Resource>(exercise23ResourceList);
        }

        public List<Exercise23Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise23ResourceList);
        }
    }
}
