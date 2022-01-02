using System.Collections.Generic;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise33
{
    public class Exercise33ResourcesList
    {
        private const string DirectoryName = "Exercise33";
        private List<Exercise33Resource> exercise33ResourceList = null;

        public Exercise33ResourcesList()
        {
            exercise33ResourceList = new List<Exercise33Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newResource = Exercise33Resource.CreateNewResource(pathToFolderSentence);

                exercise33ResourceList.Add(newResource);
            }
        }

        public List<Exercise33Resource> GetValues()
        {
            return new List<Exercise33Resource>(exercise33ResourceList.OrderBy(x => x.Number));
        }

        public List<Exercise33Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise33ResourceList);
        }
    }
}
