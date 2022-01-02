using System.Linq;
using System.IO;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise25
{
    public struct Exercise25Resource
    {
        public string[] SentencesImagesPaths { get; private set; }
        public string MainImage { get; private set; }
        public string[] SentencesSoundsPaths { get; private set; }
        public string[] Sentences { get; private set; }
        public string Sentence { get; private set; }
        public string Pierwsze { get; private set; }
        public string Drugie { get; private set; }
        public string Trzecie { get; private set; }
        public string Czwarte { get; private set; }
        public string Piate { get; private set; }
        public string[] CorrectId { get; private set; }

        public string GetRandomPicturePath()
        {
            return RandomResourceHelper.GetRandomPicturePath(SentencesImagesPaths);
        }

        public override string ToString()
        {
            return Sentence;
        }

        public static Exercise25Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string pathToSounds = Directory.GetDirectories(pathToFolderSentence).Last();
            string[] pathToSoundsFiles = Directory.GetFiles(pathToSounds);
            string pathToImgFolder = Directory.GetDirectories(pathToFolderSentence).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolderSentence).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise25", resxLocation, "texts");


            Exercise25Resource newSentence = new Exercise25Resource();
            // Zdanie 
            newSentence.Sentence = folderName;

            // Części zdania
            newSentence.Sentences = folderName.Split();

            newSentence.Pierwsze = resxManager.GetString("a", CultureInfo.CurrentCulture);
            newSentence.Drugie = resxManager.GetString("b", CultureInfo.CurrentCulture);
            newSentence.Trzecie = resxManager.GetString("c", CultureInfo.CurrentCulture);
            newSentence.Czwarte = resxManager.GetString("d", CultureInfo.CurrentCulture);
            newSentence.Piate = resxManager.GetString("e", CultureInfo.CurrentCulture);

            newSentence.CorrectId = resxManager.GetString("correctId", CultureInfo.CurrentCulture).Split(',');

            //nagrania
            newSentence.SentencesSoundsPaths = SourceHelper.GetSource(pathToSoundsFiles, "audio/mp3");

            // Sciezki do zdjec
            newSentence.SentencesImagesPaths = SourceHelper.GetSource(pathToImgFolder);

            newSentence.MainImage = SourceHelper.GetSource(pathToImgFolder).First();

            return newSentence;
        }
    }
}

