using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise22
{
    public class Exercise22ResourcesList
    {
        private const string DirectoryName = "Exercise22";
        private List<Exercise22Resource> exercise22ResourceList = null;

        public Exercise22ResourcesList()
        {
            exercise22ResourceList = new List<Exercise22Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderAmbientSound = pathToFolders[i];
                var newAmbientSound = Exercise22Resource.CreateNewResource(pathToFolderAmbientSound);

                exercise22ResourceList.Add(newAmbientSound);
            }
        }

        public List<Exercise22Resource> GetValues()
        {
            return new List<Exercise22Resource>(exercise22ResourceList);
        }

        public List<Exercise22Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise22ResourceList);
        }
    }
}
