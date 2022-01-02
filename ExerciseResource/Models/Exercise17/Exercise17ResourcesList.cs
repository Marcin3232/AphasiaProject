using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise17
{
    public class Exercise17ResourcesList
    {
        private const string DirectoryName = "Exercise17";
        private List<Exercise17Resource> categoriesList = null;

        public Exercise17ResourcesList()
        {
            categoriesList = new List<Exercise17Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSeason = pathToFolders[i];
                var newSeason = Exercise17Resource.CreateNewResource(pathToFolderSeason);

                categoriesList.Add(newSeason);
            }
        }

        public List<Exercise17Resource> GetValues()
        {
            return new List<Exercise17Resource>(categoriesList);
        }

        public List<Exercise17Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(categoriesList);
        }
    }
}
