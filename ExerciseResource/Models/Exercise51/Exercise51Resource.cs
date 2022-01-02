using ExerciseResource.Helpers;
using System;
using System.Globalization;
using System.IO;

namespace ExerciseResource.Models.Exercise51
{
    public struct Exercise51Resource
    {
        public string Activity { get; private set; }
        public string ActivitySoundSrc { get; private set; }

        public string ImageScr { get; private set; }

        public string Ending { get; private set; }

        public string First { get; private set; }
        public string Middle { get; private set; }
        public string End { get; private set; }

        public string Question { get; private set; }
        public string QuestionSoundSrc { get; private set; }

        public string Verb { get; set; }
        public string VerbSoundSrc { get; set; }

        public string Noun { get; set; }
        public string NounSoundSrc { get; set; }

        public override string ToString()
        {
            return Activity;
        }

        public static Exercise51Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);



            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');



            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise51", resxLocation, "texts");


            Exercise51Resource newResource = new Exercise51Resource();

            // Teksty
            newResource.Ending = resxManager.GetString("ending", CultureInfo.CurrentCulture);
            newResource.Question = resxManager.GetString("question", CultureInfo.CurrentCulture);
            newResource.First = resxManager.GetString("first", CultureInfo.CurrentCulture);
            newResource.Middle = resxManager.GetString("middle", CultureInfo.CurrentCulture);
            newResource.End = resxManager.GetString("end", CultureInfo.CurrentCulture);

            newResource.Verb = resxManager.GetString("verb", CultureInfo.CurrentCulture);
            newResource.Noun = resxManager.GetString("noun", CultureInfo.CurrentCulture);
            newResource.Activity = string.Format("{0} {1}", newResource.Noun, newResource.Ending);

            // Sciezka do grafiki kleksa
            newResource.ImageScr = SourceHelper.GetSource(pathToFiles, "Image", "image/png");

            // Ścieżki do nagrań
            newResource.QuestionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_question", "audio/mp3");
            newResource.ActivitySoundSrc = SourceHelper.GetSource(pathToFiles, "sound_all", "audio/mp3");
            newResource.VerbSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_verb", "audio/mp3");
            newResource.NounSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_noun", "audio/mp3");

            return newResource;
        }
    }

}

