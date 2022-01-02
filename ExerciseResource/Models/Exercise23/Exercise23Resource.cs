using ExerciseResource.Helpers;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise23
{
    public struct Exercise23Resource
    {
        public string SentenceSrc { get; private set; }
        public string Sentence { get { return string.Format("{0} {1}", Preposition, SentenceEnding); } }
        public string Preposition { get; private set; }

        public string Subject { get; private set; }
        public string SentenceEnding { get; private set; }

        public string QuestionSrc { get; private set; }
        public string PresentationSrc { get; private set; }
        public string EndingSrc { get; private set; }

        public string PictureSrc { get; private set; }

        public static Exercise23Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise23", resxLocation, "texts");

            Exercise23Resource newResource = new Exercise23Resource();

            // Teksty
            newResource.Subject = resxManager.GetString("subject", CultureInfo.CurrentCulture).ToUpper();
            string sentence = resxManager.GetString("ending", CultureInfo.CurrentCulture).ToUpper();
            string[] sentenceSplit = sentence.Split();
            newResource.Preposition = sentenceSplit.First();
            var sentenceEnding = sentenceSplit.Skip(1).ToArray();
            newResource.SentenceEnding = string.Concat(sentenceEnding);

            // Ścieżki do nagrań
            newResource.PresentationSrc = SourceHelper.GetSource(pathToFiles, "sound_presentation", "audio/mp3");
            newResource.QuestionSrc = SourceHelper.GetSource(pathToFiles, "sound_question", "audio/mp3");
            newResource.EndingSrc = SourceHelper.GetSource(pathToFiles, "sound_ending", "audio/mp3");
            newResource.SentenceSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Scieżki do obrazków
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            return newResource;
        }
    }
}
