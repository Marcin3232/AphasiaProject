using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise51
{
    public class Exercise51ResourcesList
    {
        private const string DirectoryName = "Exercise51";
        private List<Exercise51Resource> exercise51ResourceList = null;

        public Exercise51ResourcesList()
        {
            exercise51ResourceList = new List<Exercise51Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise51Resource.CreateNewResource(pathToFolderSentence);

                exercise51ResourceList.Add(newsentence);
            }
        }

        public List<Exercise51Resource> GetValues()
        {
            return new List<Exercise51Resource>(exercise51ResourceList);
        }

        public List<Exercise51Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise51ResourceList);
        }
    }
}