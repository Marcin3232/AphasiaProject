using System.Collections.Generic;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise34
{
    public class Exercise34ResourcesList
    {
        private const string DirectoryName = "Exercise34";
        private List<Exercise34Resource> exercise34ResourceList = null;

        public Exercise34ResourcesList()
        {
            exercise34ResourceList = new List<Exercise34Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise34Resource.CreateNewResource(pathToFolderSentence);

                exercise34ResourceList.Add(newResource);
            }
        }

        public List<Exercise34Resource> GetValues()
        {
            return new List<Exercise34Resource>(exercise34ResourceList.OrderBy(x => x.Number));
        }

        public List<Exercise34Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise34ResourceList);
        }
    }
}
