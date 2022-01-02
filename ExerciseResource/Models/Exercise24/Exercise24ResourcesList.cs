using System.Collections.Generic;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise24
{
    public class Exercise24ResourcesList
    {
        public const string DirectoryName = "Exercise24";
        public List<Exercise24Resource> ResourcesList = null;

        public Exercise24ResourcesList()
        {
            string[] categories = GetCategoriesPaths();
            ResourcesList = categories.Select(x => Exercise24Resource.CreateExercise24Resource(x)).ToList();
        }
        public static string[] GetCategoriesPaths()
        {
            string[] categoriesPaths = SourceHelper.GetPathToResourceFolders(DirectoryName);
            return categoriesPaths;
        }

        public MemoryCard[] GetCardsFromCategory(int ammount, string categoryName)
        {
            return ResourcesList.Single(x => x.CategoryName == categoryName).Cards;
        }
    }

}
