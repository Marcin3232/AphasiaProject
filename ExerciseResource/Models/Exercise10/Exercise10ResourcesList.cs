using System.Collections.Generic;
using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise10
{
    public class Exercise10ResourcesList
    {
        private const string DirectoryName = "Exercise10";
        private List<Exercise10Resource> exercise10ResourceList = null;

        public Exercise10ResourcesList()
        {
            exercise10ResourceList = new List<Exercise10Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            // wszystkie pliki, ze wszystkich kategorii
            // TODO: Obsługa pojedynczych kategorii
            foreach (string folderPath in pathToFolders)
            {
                string[] pathsToCategories = Directory.GetDirectories(folderPath);
                foreach (string categoryPath in pathsToCategories)
                {
                    Exercise10Resource exercise10Resource = Exercise10Resource.CreateExercise10Resource(categoryPath);

                    exercise10ResourceList.Add(exercise10Resource);
                }
            }
        }

        public List<Exercise10Resource> GetValues()
        {
            return new List<Exercise10Resource>(exercise10ResourceList);
        }

        public List<Exercise10Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise10ResourceList);
        }
    }
}
