using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise16
{
    public class Exercise16ResourcesList
    {
        private const string DirectoryName = "Exercise16";
        private List<Exercise16Resource> categoriesList = null;
        private List<UsingResource> usingResourcesList = null;

        public Exercise16ResourcesList()
        {
            categoriesList = new List<Exercise16Resource>();
            usingResourcesList = new List<UsingResource>();
            string directoryName = DirectoryName;
            string directoryNameResources = directoryName + "/Nauka";
            string directoryNameResourcesUsing = directoryName + "/Using";
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryNameResources);
            string[] pathToFoldersUsing = SourceHelper.GetPathToResourceFolders(directoryNameResourcesUsing);
            GetData(pathToFolders);
            GetDataUsing(pathToFoldersUsing);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolder = pathToFolders[i];
                var newAdjective = Exercise16Resource.CreateNewResource(pathToFolder);

                categoriesList.Add(newAdjective);
            }
        }

        private void GetDataUsing(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolder = pathToFolders[i];
                var newUsingResource = UsingResource.CreateNewUsingResource(pathToFolder);

                usingResourcesList.Add(newUsingResource);
            }
        }
        public List<Exercise16Resource> GetValues()
        {
            return new List<Exercise16Resource>(categoriesList);
        }

        public List<Exercise16Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(categoriesList);
        }
        public List<UsingResource> GetRandomValuesUsing()
        {
            return RandomResourceHelper.GetRandomValues(usingResourcesList);
        }
    }
}
