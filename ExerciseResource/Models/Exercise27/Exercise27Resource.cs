using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise27
{
    public struct Exercise27Resource
    {
        public string CategoryName { get; private set; }
        public string CategoryNameAudio { get; private set; }
        public string PointQuestionAudio { get; private set; }
        public List<Subcategory> Subcategories { get; private set; }

        public override string ToString()
        {
            return CategoryName;
        }

        public static Exercise27Resource CreateNewResource(string pathToFolderAdjective)
        {
            string folderName = Path.GetFileName(pathToFolderAdjective);
            string[] pathToFiles = Directory.GetFiles(pathToFolderAdjective);
            string[] pathsToSubcategoriesNames = Directory.GetDirectories(pathToFolderAdjective);

            Exercise27Resource newResource = new Exercise27Resource();
            newResource.CategoryName = folderName.ToUpper();
            newResource.CategoryNameAudio = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");
            newResource.PointQuestionAudio = SourceHelper.GetSource(pathToFiles, "sound2", "audio/mp3");
            newResource.Subcategories = new List<Subcategory>();

            for (int i = 0; i < pathsToSubcategoriesNames.Length; i++)
            {
                Subcategory newSubcategory = Subcategory.CreateNewSubcategory(pathsToSubcategoriesNames[i], folderName);
                newResource.Subcategories.Add(newSubcategory);
            }

            return newResource;
        }
        public class Subcategory
        {
            public string SubcategoryName { get; private set; }
            public string SubcategoryNameAudio { get; private set; }
            public string SubcategoryNounPictureSrc { get; private set; }
            public string SubcategorySentencePictureSrc { get; private set; }
            public string SubcategorySentenceString { get; private set; }
            public string SubcategorySentenceAudio { get; private set; }

            public static Subcategory CreateNewSubcategory(string subcategoryDirectoryPath, string categoryName)
            {
                string[] pathsToSubcategoryFiles = Directory.GetFiles(subcategoryDirectoryPath);
                string pathToNounImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).Last();
                string pathToSentenceImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).First();
                string subcategoryName = Path.GetFileName(subcategoryDirectoryPath);

                Subcategory newSubcategory = new Subcategory();
                newSubcategory.SubcategoryNameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");
                newSubcategory.SubcategorySentenceAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound2", "audio/mp3");

                var nounPictureSrcs = SourceHelper.GetSource(pathToNounImgFolder);
                newSubcategory.SubcategoryNounPictureSrc = RandomResourceHelper.GetRandomPicturePath(nounPictureSrcs);


                var sentencePictureSrcs = SourceHelper.GetSource(pathToSentenceImgFolder);
                newSubcategory.SubcategorySentencePictureSrc = RandomResourceHelper.GetRandomPicturePath(sentencePictureSrcs);


                newSubcategory.SubcategoryName = Path.GetFileName(subcategoryDirectoryPath).ToUpper();
                subcategoryName = subcategoryName.Replace(' ', '_');

                var resxManager = SourceHelper.GetResxFile("Exercise27", categoryName + "." + subcategoryName, "sentence");
                newSubcategory.SubcategorySentenceString = resxManager.GetString("subcategorySentence", CultureInfo.CurrentCulture);
                newSubcategory.SubcategorySentenceString += " ...";

                return newSubcategory;
            }
        }
    }
}

