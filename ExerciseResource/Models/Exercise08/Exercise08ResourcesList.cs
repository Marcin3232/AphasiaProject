using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise08
{
    public class Exercise08ResourcesList
    {
        private const string DirectoryName = "Exercise08";
        private List<Exercise08Resource> exercise08ResourceList = null;

        public Exercise08ResourcesList()
        {
            exercise08ResourceList = new List<Exercise08Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderVerb = pathToFolders[i];
                var newVerb = Exercise08Resource.CreateNewResource(pathToFolderVerb);

                exercise08ResourceList.Add(newVerb);
            }
        }

        public List<Exercise08Resource> GetValues()
        {
            return new List<Exercise08Resource>(exercise08ResourceList);
        }

        public List<Exercise08Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise08ResourceList);
        }
    }
}
