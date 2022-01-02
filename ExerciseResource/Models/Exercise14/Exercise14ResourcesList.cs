using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise14
{
    public class Exercise14ResourcesList
    {
        private const string DirectoryName = "Exercise14";
        private List<Exercise14Resource> exercise14ResourceList = null;

        public Exercise14ResourcesList()
        {
            exercise14ResourceList = new List<Exercise14Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderNoun = pathToFolders[i];
                var newResource = Exercise14Resource.CreateNewResource(pathToFolderNoun);

                exercise14ResourceList.Add(newResource);
            }
        }

        public List<Exercise14Resource> GetValues()
        {
            return new List<Exercise14Resource>(exercise14ResourceList);
        }

        public List<Exercise14Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise14ResourceList);
        }
    }
}
