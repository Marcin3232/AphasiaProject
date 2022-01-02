using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise16
{
    public struct Exercise16Resource
    {
        public string CategoryName { get; private set; }
        public List<Subcategory> Subcategories { get; private set; }

        public override string ToString()
        {
            return CategoryName;
        }
        public static Exercise16Resource CreateNewResource(string pathToFolderAdjective)
        {
            string folderName = Path.GetFileName(pathToFolderAdjective);
            string[] pathToFiles = Directory.GetFiles(pathToFolderAdjective);
            //poniżej ściągamy ścieżki do kolejnych folderów których nazwy to podkategorie
            string[] pathsToSubcategoriesNames = Directory.GetDirectories(pathToFolderAdjective);
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolderAdjective).Replace(' ', '_');
            Exercise16Resource newResource = new Exercise16Resource();
            //nazwa danej kategorii(wysoki, niski itp)
            newResource.CategoryName = folderName.ToUpper();

            //obiekty podkategorii - dla auta: osobowe, ciężarowe itd.
            //każdy obiekt ma nazwę - zgodną z nazwą podkategorii, audio - lektor czytający nazwę podkategorii oraz tablicę z obrazkami


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
            public string SubcategoryPictureSrc { get; private set; }
            public string SubcategoryChangedNameAudio { get; private set; }
            public string SubcategoryNounAndAdjectiveSound { get; private set; }
            public static Subcategory CreateNewSubcategory(string subcategoryDirectoryPath, string categoryName)
            {
                Subcategory newSubcategory = new Subcategory();
                newSubcategory.SubcategoryName = Path.GetFileName(subcategoryDirectoryPath).ToUpper();
                string[] pathsToSubcategoryFiles = Directory.GetFiles(subcategoryDirectoryPath);
                newSubcategory.SubcategoryNameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");
                newSubcategory.SubcategoryChangedNameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound2", "audio/mp3");
                newSubcategory.SubcategoryNounAndAdjectiveSound = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound3", "audio/mp3");
                string pathToImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).First();

                var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
                newSubcategory.SubcategoryPictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


                string resxLocation = Path.GetFileName(subcategoryDirectoryPath);
                return newSubcategory;
            }



        }

    }
    public struct UsingResource
    {
        public string NounName { get; private set; }
        public string NameAudio { get; private set; }
        public string PicturesSrc { get; private set; }
        public string[] ProperAdjectives { get; private set; }
        public string[] WrongAdjectives { get; private set; }
        public static UsingResource CreateNewUsingResource(string PathToFolder)
        {
            UsingResource resource = new UsingResource();
            resource.NounName = Path.GetFileName(PathToFolder).ToUpper();
            string resxLocation = Path.GetFileName(PathToFolder);
            var resxManager = SourceHelper.GetResxFile("Exercise16.Using", resxLocation, "Text");
            string resxStringCorrect = resxManager.GetString("Proper", CultureInfo.CurrentCulture);
            string resxStringWrong = resxManager.GetString("Wrong", CultureInfo.CurrentCulture);
            string pathToImgFolder = Directory.GetDirectories(PathToFolder).First();
            resource.ProperAdjectives = resxStringCorrect.Split(',');
            resource.WrongAdjectives = resxStringWrong.Split(',');

            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            resource.PicturesSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


            string[] pathsToSubcategoryFiles = Directory.GetFiles(PathToFolder);
            resource.NameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");
            return resource;


        }
    }
}
