using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise21
{
    public class Exercise21ResourcesList
    {
        private const string DirectoryName = "Exercise21";
        private List<Exercise21Resource> categoriesList = null;

        public Exercise21ResourcesList()
        {
            categoriesList = new List<Exercise21Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSeason = pathToFolders[i];
                var newSeason = Exercise21Resource.CreateNewResource(pathToFolderSeason);

                categoriesList.Add(newSeason);
            }
        }

        public List<Exercise21Resource> GetValues()
        {
            return new List<Exercise21Resource>(categoriesList);
        }

        public List<Exercise21Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(categoriesList);
        }
    }
}
