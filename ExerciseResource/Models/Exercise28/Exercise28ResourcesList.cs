using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise28
{
    public class Exercise28ResourcesList
    {
        private const string DirectoryName = "Exercise28";
        private List<Exercise28Resource> exercise28ResourceList = null;

        public Exercise28ResourcesList()
        {
            exercise28ResourceList = new List<Exercise28Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise28Resource.CreateNewResource(pathToFolderSentence);

                exercise28ResourceList.Add(newsentence);
            }
        }

        public List<Exercise28Resource> GetValues()
        {
            return new List<Exercise28Resource>(exercise28ResourceList);
        }

        public List<Exercise28Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise28ResourceList);
        }
    }
}
