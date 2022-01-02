using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise27
{
    public class Exercise27ResourcesList
    {
        private const string DirectoryName = "Exercise27";
        private List<Exercise27Resource> categoriesList = null;

        public Exercise27ResourcesList()
        {
            categoriesList = new List<Exercise27Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSeason = pathToFolders[i];
                var newSeason = Exercise27Resource.CreateNewResource(pathToFolderSeason);

                categoriesList.Add(newSeason);
            }
        }

        public List<Exercise27Resource> GetValues()
        {
            return new List<Exercise27Resource>(categoriesList);
        }

        public List<Exercise27Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(categoriesList);
        }
    }
}
