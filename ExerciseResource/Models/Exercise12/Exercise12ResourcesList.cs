using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise12
{
    public class Exercise12ResourcesList
    {
        private const string DirectoryName = "Exercise12";
        private List<Exercise12Resource> colorList = null;

        public Exercise12ResourcesList()
        {
            colorList = new List<Exercise12Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderColor = pathToFolders[i];
                var newColor = Exercise12Resource.CreateNewResource(pathToFolderColor);

                colorList.Add(newColor);
            }
        }

        public List<Exercise12Resource> GetValues()
        {
            return new List<Exercise12Resource>(colorList);
        }

        public List<Exercise12Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(colorList);
        }
    }
}
