using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise02
{
    public struct Exercise02Resource
    {
        public List<string> PartOneVideoSrcs { get; private set; }
        public List<string> PartTwoVideoSrcs { get; private set; }
        public List<string> PartThreeVideoSrcs { get; private set; }
        public List<string> FullSentenceSound { get; private set; }

        public static Exercise02Resource CreateExercise02Resource(string pathToFolder)
        {
            Exercise02Resource newExercise02Resource = new Exercise02Resource();

            //string pathToProjectFolder = Directory.GetParent(pathToFolder)
            //    .Parent
            //    .Parent
            //    .Parent.FullName; // powrót do głównego katalogu
            //string pathToInstructionFolder = String.Format("{0}\\AfastPowiedzTo\\Content\\Videos\\WarmUp\\", pathToProjectFolder);
            // dodanie ścieżki do katalogu z nagraniami
            string[] partsDirectories = Directory.GetDirectories(pathToFolder);

            // Kiedyś była taka fajna laborka, z takim fajnym prowadzącym, który pokazał mi linq
            // To był błąd z jego strony.

            var partOneBaseFilePaths = Directory.GetFiles(partsDirectories[0])
                .Where((x, i) => i % 2 != 1)
                .Select(x => getLinkFromResxFilePath(x))
                .ToList();
            var partTwoBaseFilePaths = Directory.GetFiles(partsDirectories[1])
                .Where((x, i) => i % 2 != 1)
                .Select(x => getLinkFromResxFilePath(x))
                .ToList();
            var partThreeBaseFilePaths = Directory.GetFiles(partsDirectories[2])
                .Where((x, i) => i % 2 != 1)
                .Select(x => getLinkFromResxFilePath(x))
                .ToList();

            // Resxy składają się z dwóch plików, dlatego wybieram co drugi

            newExercise02Resource.PartOneVideoSrcs = partOneBaseFilePaths;
            newExercise02Resource.PartTwoVideoSrcs = partTwoBaseFilePaths;
            newExercise02Resource.PartThreeVideoSrcs = partThreeBaseFilePaths;

            return newExercise02Resource;
        }

        private static string getLinkFromResxFilePath(string absolutePath)
        {
            string partName = Path.GetDirectoryName(absolutePath);
            string resourceName = Path.GetDirectoryName(partName);
            string fileName = Path.GetFileName(absolutePath); // usunięcie .Designer.cs z konca
            fileName = fileName.Substring(0, fileName.Length - 12);
            partName = Path.GetFileName(partName);
            resourceName = Path.GetFileName(resourceName);
            string resxRelativeLocation = string.Format("{0}.{1}", resourceName, partName);

            var resxManager = SourceHelper.GetResxFile("Exercise02", resxRelativeLocation, fileName);
            string link = resxManager.GetString("Link", CultureInfo.CurrentCulture);

            return link;
        }
    }
}
