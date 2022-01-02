using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise31
{
    public class Exercise31ResourcesList
    {
        private const string DirectoryName = "Exercise31";
        private List<Exercise31Resource> categoriesList = null;

        public Exercise31ResourcesList()
        {
            categoriesList = new List<Exercise31Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);
            string temporatyPath = pathToFolders[0];
            pathToFolders[0] = pathToFolders[2];
            pathToFolders[2] = temporatyPath;
            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSeason = pathToFolders[i];
                var newTimeTerm = Exercise31Resource.CreateNewResource(pathToFolderSeason);

                categoriesList.Add(newTimeTerm);
            }
        }

        public List<Exercise31Resource> GetValues()
        {
            return new List<Exercise31Resource>(categoriesList);
        }

        public List<Exercise31Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(categoriesList);
        }
    }
}
