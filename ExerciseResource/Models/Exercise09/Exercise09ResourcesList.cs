using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise09
{
    public class Exercise09ResourcesList
    {
        private const string DirectoryName = "Exercise09";
        private List<Exercise09Resource> exercise09ResourceList = null;

        public Exercise09ResourcesList()
        {
            exercise09ResourceList = new List<Exercise09Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise09Resource.CreateNewResource(pathToFolderSentence);

                exercise09ResourceList.Add(newResource);
            }
        }

        public List<Exercise09Resource> GetValues()
        {
            return new List<Exercise09Resource>(exercise09ResourceList);
        }

        public List<Exercise09Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise09ResourceList);
        }
    }
}
