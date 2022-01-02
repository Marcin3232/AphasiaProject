using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise31
{
    public struct Exercise31Resource
    {
        public string MealName { get; private set; }
        public string MealNameAudio { get; private set; }
        public string HourAudio { get; private set; }
        public string HourString { get; private set; }
        public string[] ClockImages { get; private set; }
        public string[] TimeTermString { get; private set; }
        public string[] Questions { get; private set; }
        public List<Subcategory> Subcategories { get; private set; }

        public override string ToString()
        {
            return MealName;
        }

        public static Exercise31Resource CreateNewResource(string pathToFolderAdjective)
        {
            string folderName = Path.GetFileName(pathToFolderAdjective);
            string[] pathToFiles = Directory.GetFiles(pathToFolderAdjective);
            string[] pathsToSubcategoriesNames = Directory.GetDirectories(pathToFolderAdjective);

            Exercise31Resource newResource = new Exercise31Resource();
            newResource.MealName = folderName.ToUpper();
            newResource.MealNameAudio = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");
            newResource.HourAudio = SourceHelper.GetSource(pathToFiles, "sound2", "audio/mp3");
            newResource.Subcategories = new List<Subcategory>();
            newResource.ClockImages = SourceHelper.GetSource(pathsToSubcategoriesNames[0]);
            newResource.TimeTermString = new string[3];
            newResource.Questions = new string[3];

            string currentDirectoryName = Path.GetFileName(pathToFolderAdjective).Replace(' ', '_');
            var resxManager = SourceHelper.GetResxFile("Exercise31", currentDirectoryName, "TimeTerm");

            newResource.TimeTermString[0] = resxManager.GetString("beforeTerm", CultureInfo.CurrentCulture);
            newResource.TimeTermString[1] = resxManager.GetString("forTerm", CultureInfo.CurrentCulture);
            newResource.TimeTermString[2] = resxManager.GetString("afterTerm", CultureInfo.CurrentCulture);
            newResource.Questions[0] = resxManager.GetString("question1", CultureInfo.CurrentCulture);
            newResource.Questions[1] = resxManager.GetString("question2", CultureInfo.CurrentCulture);
            newResource.Questions[2] = resxManager.GetString("question3", CultureInfo.CurrentCulture);
            newResource.HourString = resxManager.GetString("time", CultureInfo.CurrentCulture);

            string temporaryString1 = pathsToSubcategoriesNames[1];
            string temporaryString2 = pathsToSubcategoriesNames[2];

            pathsToSubcategoriesNames[1] = pathsToSubcategoriesNames[3];
            pathsToSubcategoriesNames[2] = temporaryString1;
            pathsToSubcategoriesNames[3] = temporaryString2;

            for (int i = 1; i < pathsToSubcategoriesNames.Length; i++)
            {
                Subcategory newSubcategory = Subcategory.CreateNewSubcategory(pathsToSubcategoriesNames[i]);
                newResource.Subcategories.Add(newSubcategory);
            }

            return newResource;
        }
        public class Subcategory
        {
            public string TimeTerm { get; private set; }
            public string TimeTermAudio { get; private set; }
            public string TimeTermShortAudio { get; private set; }
            public string[] TimeTermPicturesSrc { get; private set; }
            public string SayWhenAudio { get; private set; }
            public string WhenAudio { get; private set; }
            public string[] ClockImages { get; private set; }

            public static Subcategory CreateNewSubcategory(string subcategoryDirectoryPath)
            {
                string[] pathsToSubcategoryFiles = Directory.GetFiles(subcategoryDirectoryPath);
                string pathToImgFolder = Directory.GetDirectories(subcategoryDirectoryPath).First();

                Subcategory newSubcategory = new Subcategory();
                newSubcategory.TimeTermAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound", "audio/mp3");
                newSubcategory.TimeTermShortAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound1", "audio/mp3");
                newSubcategory.SayWhenAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound2", "audio/mp3");
                newSubcategory.WhenAudio = SourceHelper.GetSource(pathsToSubcategoryFiles, "sound3", "audio/mp3");
                newSubcategory.TimeTermPicturesSrc = SourceHelper.GetSource(pathToImgFolder);
                newSubcategory.TimeTerm = Path.GetFileName(subcategoryDirectoryPath).ToUpper();

                return newSubcategory;
            }
        }
    }
}

