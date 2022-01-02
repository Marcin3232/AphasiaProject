using System.Collections.Generic;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise29
{
    public class Exercise29ResourcesList
    {
        public const string DirectoryName = "Exercise29";
        public List<Exercise29Resource> ResourceList { get; private set; }

        public Exercise29ResourcesList()
        {
            string[] storiesDirectoryPaths = GetStoriesPaths();
            ResourceList = storiesDirectoryPaths.Select(path => Exercise29Resource.CreateExercise29Resource(path)).ToList();
        }

        public static string[] GetStoriesPaths()
        {
            string[] categoriesPaths = SourceHelper.GetPathToResourceFolders(DirectoryName);
            return categoriesPaths;
        }
    }
}
