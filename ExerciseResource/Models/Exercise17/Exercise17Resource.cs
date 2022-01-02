using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise17
{
    public struct Exercise17Resource
    {
        public string CategoryName { get; private set; }
        public string CategoryNameAudio { get; private set; }
        public string AdjectiveAudio { get; private set; }
        public string Adjective { get; private set; }

        public List<Subcategory> Subcategories { get; private set; }
        public string[] SubcategoriesAudio { get; private set; }

        public override string ToString()
        {
            return CategoryName;
        }

        public static Exercise17Resource CreateNewResource(string pathToFolderAdjective)
        {
            string folderName = Path.GetFileName(pathToFolderAdjective);
            string[] pathToFiles = Directory.GetFiles(pathToFolderAdjective);

            //poniżej ściągamy ścieżki do kolejnych folderów których nazwy to podkategorie
            string[] pathsToSubcategoriesNames = Directory.GetDirectories(pathToFolderAdjective);
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolderAdjective).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise17", resxLocation, "Adjective");

            Exercise17Resource newResource = new Exercise17Resource();

            //nazwa danej kategorii(auto, buty itp)
            newResource.CategoryName = folderName.ToUpper();

            //plik mp3 z nazwą kategorii
            newResource.CategoryNameAudio = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            //plik mp3 z przymiotnikiem(jaki, jaka, jakie), adekwatnym do kategorii
            newResource.AdjectiveAudio = SourceHelper.GetSource(pathToFiles, "adjective", "audio/mp3");

            //przymiotnik używany w danej kategorii
            newResource.Adjective = resxManager.GetString("adjective", CultureInfo.CurrentCulture);

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

        ///////////////////////////////////////////////////
        public class Subcategory
        {
            public string SubcategoryName { get; private set; }
            public string SubcategoryNameAudio { get; private set; }
            public string SubcategoryPictureSrc { get; private set; }
            public string SentenceBeginning { get; private set; }
            public string SentenceEnding { get; private set; }
            public string SentenceAudio { get; private set; }


            public static Subcategory CreateNewSubcategory(string subcategoryDirectoryPath, string categoryName)
            {
                Subcategory newSubcategory = new Subcategory();
                newSubcategory.SubcategoryName = Path.GetFileName(subcategoryDirectoryPath).ToUpper();

                string[] pathsToSubcategoryFiles = Directory.GetFiles(subcategoryDirectoryPath);
                string pathToImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).First();
                string resxLocation = Path.GetFileName(subcategoryDirectoryPath);
                var resxManager = SourceHelper.GetResxFile("Exercise17." + categoryName, resxLocation, "Sentences");

                newSubcategory.SubcategoryNameAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");
                newSubcategory.SentenceAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sentence", "audio/mp3");

                var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
                newSubcategory.SubcategoryPictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

                newSubcategory.SentenceBeginning = resxManager.GetString("beginning", CultureInfo.CurrentCulture);
                newSubcategory.SentenceEnding = resxManager.GetString("ending", CultureInfo.CurrentCulture);

                return newSubcategory;
            }
        }
        ///////////////////////////////////////////////////
    }
}

