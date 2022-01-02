using ExerciseResource.Helpers;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise28
{
    public struct Exercise28Resource
    {
        public string Proverb { get; private set; }
        public string ProverbSoundSrc { get; private set; }

        public string Description { get; private set; }
        public string DescriptionSoundSrc { get; private set; }

        public string Beginning { get; private set; }
        public string BeginningSoundSrc { get; private set; }

        public string Ending { get; private set; }
        public string EndingSoundSrc { get; private set; }

        public string PictureSrc { get; private set; }

        public override string ToString()
        {
            return Proverb;
        }

        public static Exercise28Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise28", resxLocation, "texts");

            Exercise28Resource newResource = new Exercise28Resource();

            // Teksty
            newResource.Beginning = resxManager.GetString("beginning", CultureInfo.CurrentCulture);
            newResource.Ending = resxManager.GetString("ending", CultureInfo.CurrentCulture);
            newResource.Description = resxManager.GetString("description", CultureInfo.CurrentCulture);

            newResource.Proverb = string.Format("{0}{1}", newResource.Beginning, newResource.Ending);

            // Ścieżki do nagrań
            newResource.BeginningSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_beginning", "audio/mp3");
            newResource.EndingSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_ending", "audio/mp3");
            newResource.DescriptionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_description", "audio/mp3");
            newResource.ProverbSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_all", "audio/mp3");

            // Scieżki do obrazków
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            return newResource;
        }
    }
}
