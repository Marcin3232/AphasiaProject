using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise41
{
    public class Exercise41ResourcesList
    {
        private const string DirectoryName = "Exercise41";
        private List<Exercise41Resource> exercise41ResourceList = null;

        public Exercise41ResourcesList()
        {
            exercise41ResourceList = new List<Exercise41Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise41Resource.CreateNewResource(pathToFolderSentence);

                exercise41ResourceList.Add(newsentence);
            }
        }

        public List<Exercise41Resource> GetValues()
        {
            return new List<Exercise41Resource>(exercise41ResourceList);
        }
        public List<Exercise41Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise41ResourceList);
        }
    }
}
