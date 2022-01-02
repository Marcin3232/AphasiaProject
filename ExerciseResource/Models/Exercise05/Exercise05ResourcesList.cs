using ExerciseResource.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseResource.Models.Exercise05
{
    public class Exercise05ResourcesList
    {
        private const string DirectoryName = "Exercise05";
        private List<Exercise05Resource> exercise05ResourceList = null;

        public Exercise05ResourcesList()
        {
            exercise05ResourceList = new List<Exercise05Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise05Resource.CreateNewResource(pathToFolderSentence);

                exercise05ResourceList.Add(newResource);
            }
        }

        public List<Exercise05Resource> GetValues()
        {
            return new List<Exercise05Resource>(exercise05ResourceList.OrderBy(x => x.Number));
        }

        public List<Exercise05Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues<Exercise05Resource>(exercise05ResourceList);
        }
    }
}
