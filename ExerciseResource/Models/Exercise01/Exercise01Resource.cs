using ExerciseResource.Helpers;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise01
{
    public struct Exercise01Resource
    {
        public string Word { get; private set; }
        public string WordSoundSrc { get; private set; }
        public string InstructionSoundSrc { get; private set; }
        public string[] PicturesSrcs { get; private set; }

        public string GetRandomPicturePath()
        {
            return RandomResourceHelper.GetRandomPicturePath(PicturesSrcs);
        }

        public override string ToString()
        {
            return Word;
        }

        public static Exercise01Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            Exercise01Resource newResource = new Exercise01Resource();

            // Słowo
            newResource.Word = folderName.ToUpper();

            // Ścieżka do pliku z nagraniem słowa
            newResource.WordSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Ścieżka do pliku z nagraniem instrukcji
            newResource.InstructionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_instruction", "audio/mp3");

            // Ścieżki do obrazów
            newResource.PicturesSrcs = SourceHelper.GetSource(pathToImgFolder);

            return newResource;
        }
    }
}
