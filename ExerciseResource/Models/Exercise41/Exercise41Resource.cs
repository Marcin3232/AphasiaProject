using ExerciseResource.Helpers;
using System;
using System.Globalization;
using System.IO;

namespace ExerciseResource.Models.Exercise41
{
    public struct Exercise41Resource
    {
        public string Phrasal { get; private set; }
        public string PhrasalSoundSrc { get; private set; }

        public string Description { get; private set; }
        public string DescriptionSoundSrc { get; private set; }

        public string Beginning { get; private set; }
        public string BeginningSoundSrc { get; private set; }

        public string Ending { get; private set; }
        public string EndingSoundSrc { get; private set; }

        public string Question { get; private set; }
        public string QuestionSoundSrc { get; private set; }

        public override string ToString()
        {
            return Phrasal;
        }

        public static Exercise41Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise41", resxLocation, "texts");

            Exercise41Resource newResource = new Exercise41Resource();

            // Teksty
            newResource.Beginning = resxManager.GetString("beginning", CultureInfo.CurrentCulture);
            newResource.Ending = resxManager.GetString("ending", CultureInfo.CurrentCulture);
            newResource.Description = resxManager.GetString("description", CultureInfo.CurrentCulture);
            newResource.Question = resxManager.GetString("question", CultureInfo.CurrentCulture);

            newResource.Phrasal = string.Format("{0}{1}", newResource.Beginning, newResource.Ending);

            // Ścieżki do nagrań
            newResource.BeginningSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_beginning", "audio/mp3");
            newResource.EndingSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_ending", "audio/mp3");
            newResource.DescriptionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_description", "audio/mp3");
            newResource.QuestionSoundSrc = newResource.DescriptionSoundSrc;
            newResource.PhrasalSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_all", "audio/mp3");

            return newResource;
        }
    }
}
