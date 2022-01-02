using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise13
{
    public struct Exercise13Resource
    {
        public string Name { get; private set; }

        public string NameSoundSrc { get; private set; }

        public string SentenceSoundSrc { get; private set; }

        public string SentenceString { get; private set; }

        public string QuestionString { get; private set; }

        public string QuestionSoundSrc { get; private set; }

        public string PictureSrc { get; private set; }


        public override string ToString()
        {
            return Name;
        }

        public static Exercise13Resource CreateNewResource(string pathToFolderSeason)
        {
            string folderName = Path.GetFileName(pathToFolderSeason);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSeason);

            string pathToImgFolder = Directory
                .GetDirectories(pathToFolderSeason)
                .First();

            string currentTemplateDirectoryName = Path.GetFileName(pathToFolderSeason).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise13", resxLocation, "SeasonSentences");

            Exercise13Resource newResource = new Exercise13Resource();

            // Nazwa pory roku
            newResource.Name = folderName.ToUpper();

            // Sciezka do pliku .mp3 z nazwa pory roku
            newResource.NameSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Ścieżka do pliku .mp3 ze zdaniem typu "coś tam się dzieje bo to..."
            newResource.SentenceSoundSrc = SourceHelper.GetSource(pathToFiles, "sound2", "audio/mp3");

            // Ścieżka do pliku .mp3 z pytaniem typu "coś tam się dzieje co to?"
            newResource.QuestionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound3", "audio/mp3");

            // Sciezki do zdjec w danym kolorze
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            // Teksty - pytanie jak i całe zdanie
            newResource.QuestionString = resxManager.GetString("Question", CultureInfo.CurrentCulture);
            newResource.SentenceString = resxManager.GetString("Sentence", CultureInfo.CurrentCulture);

            return newResource;
        }
    }
}

