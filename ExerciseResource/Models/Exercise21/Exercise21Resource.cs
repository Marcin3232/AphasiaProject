using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise21
{
    public struct Exercise21Resource
    {
        public string CategoryName { get; private set; }
        public string CategoryNameAudio { get; private set; }
        public string PointCategoryAudio { get; private set; }
        public List<Subcategory> Subcategories { get; private set; }

        public override string ToString()
        {
            return CategoryName;
        }

        public static Exercise21Resource CreateNewResource(string pathToFolderAdjective)
        {
            string folderName = Path.GetFileName(pathToFolderAdjective);
            string[] pathToFiles = Directory.GetFiles(pathToFolderAdjective);
            string[] pathsToSubcategoriesNames = Directory.GetDirectories(pathToFolderAdjective);

            Exercise21Resource newResource = new Exercise21Resource();
            newResource.CategoryName = folderName.ToUpper();
            newResource.CategoryNameAudio = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");
            newResource.PointCategoryAudio = SourceHelper.GetSource(pathToFiles, "sound2", "audio/mp3");
            newResource.Subcategories = new List<Subcategory>();

            for (int i = 0; i < pathsToSubcategoriesNames.Length; i++)
            {
                Subcategory newSubcategory = Subcategory.CreateNewSubcategory(pathsToSubcategoriesNames[i]);
                newResource.Subcategories.Add(newSubcategory);
            }

            return newResource;
        }
        public class Subcategory
        {
            public string SubcategoryName { get; private set; }
            public string SubcategoryNameAudio { get; private set; }
            public string SubcategoryPictureSrc { get; private set; }

            public static Subcategory CreateNewSubcategory(string subcategoryDirectoryPath)
            {
                string[] pathsToSubcategoryFiles = Directory.GetFiles(subcategoryDirectoryPath);
                string pathToImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).First();

                Subcategory newSubcategory = new Subcategory();
                newSubcategory.SubcategoryNameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");

                var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
                newSubcategory.SubcategoryPictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

                newSubcategory.SubcategoryName = Path.GetFileName(subcategoryDirectoryPath).ToUpper();

                return newSubcategory;
            }
        }
    }
}

