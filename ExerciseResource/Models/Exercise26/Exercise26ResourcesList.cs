using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise26
{
    public class Exercise26ResourcesList
    {
        private const string DirectoryName = "Exercise26";
        private List<Exercise26Resource> exercise26ResourceList = null;

        public Exercise26ResourcesList()
        {
            exercise26ResourceList = new List<Exercise26Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise26Resource.CreateNewResource(pathToFolderSentence);

                exercise26ResourceList.Add(newsentence);
            }
        }

        public List<Exercise26Resource> GetValues()
        {
            return new List<Exercise26Resource>(exercise26ResourceList);
        }

        public List<Exercise26Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise26ResourceList);
        }
    }
}