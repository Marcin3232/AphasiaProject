using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise25
{
    public class Exercise25ResourcesList
    {
        private const string DirectoryName = "Exercise25";
        private List<Exercise25Resource> exercise25ResourcesList = null;

        public Exercise25ResourcesList()
        {
            exercise25ResourcesList = new List<Exercise25Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise25Resource.CreateNewResource(pathToFolderSentence);

                exercise25ResourcesList.Add(newsentence);
            }
        }

        public List<Exercise25Resource> GetValues()
        {
            return new List<Exercise25Resource>(exercise25ResourcesList);
        }

        public List<Exercise25Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise25ResourcesList);
        }
    }
}
