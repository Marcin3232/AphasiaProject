using System.Collections.Generic;
using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise60
{
    public class Exercise60ResourcesList
    {
        private const string DirectoryName = "Exercise60";
        private List<Exercise60Resource> exercise60ResourceList = null;

        public Exercise60ResourcesList()
        {
            exercise60ResourceList = new List<Exercise60Resource>();

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
                    Exercise60Resource exercise60Resource = Exercise60Resource.CreateExercise60Resource(categoryPath);

                    exercise60ResourceList.Add(exercise60Resource);
                }
            }
        }

        public List<Exercise60Resource> GetValues()
        {
            return new List<Exercise60Resource>(exercise60ResourceList);
        }

        public List<Exercise60Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise60ResourceList);
        }
    }
}
