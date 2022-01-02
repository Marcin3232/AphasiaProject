using System.Collections.Generic;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise13
{
    public class Exercise13ResourcesList
    {
        private const string DirectoryName = "Exercise13";
        private List<Exercise13Resource> seasonList = null;

        public Exercise13ResourcesList()
        {
            seasonList = new List<Exercise13Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSeason = pathToFolders[i];
                var newSeason = Exercise13Resource.CreateNewResource(pathToFolderSeason);

                seasonList.Add(newSeason);
            }
        }

        public List<Exercise13Resource> GetValuesWithProperOrdes()
        {
            List<Exercise13Resource> newList = new List<Exercise13Resource>();
            string[] seasonsOrder = new string[] { "WIOSNA", "LATO", "JESIEŃ", "ZIMA" };
            for (int i = 0; i < seasonsOrder.Length; i++)
            {
                var season = seasonList.Single(x => x.Name == seasonsOrder[i]);
                newList.Add(season);
            }
            return new List<Exercise13Resource>(newList);

        }

    }
}
