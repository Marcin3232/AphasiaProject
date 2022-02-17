using ExerciseResource.Helpers;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise01
{
    public class Exercise01ResourcesList
    {
        private const string DirectoryName = "Exercise01";
        private List<Exercise01Resource> exercise01ResourceList = null;

        public Exercise01ResourcesList()
        {
            exercise01ResourceList = new List<Exercise01Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderWord = pathToFolders[i];
                var newWord = Exercise01Resource.CreateNewResource(pathToFolderWord);

                exercise01ResourceList.Add(newWord);
            }
        }

        public List<Exercise01Resource> GetValues()
        {
            return new List<Exercise01Resource>(exercise01ResourceList);
        }

        public List<Exercise01Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues<Exercise01Resource>(exercise01ResourceList);
        }

        public List<Exercise01Resource> GetRandomValues(out int[] randomIndexes)
        {
            List<Exercise01Resource> randomValues = null;

            randomValues = RandomResourceHelper.GetRandomValues<Exercise01Resource>
                (exercise01ResourceList, out randomIndexes);

            return randomValues;
        }
    }
}
