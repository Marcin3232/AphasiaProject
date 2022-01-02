using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise08
{
    public struct Exercise08Resource
    {
        public string Verb { get; private set; }
        public string VerbSoundSrc { get; private set; }
        public string PictureSrc { get; private set; }

        public override string ToString()
        {
            return Verb;
        }

        public static Exercise08Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            Exercise08Resource newResource = new Exercise08Resource();

            // Czasownik
            newResource.Verb = folderName.ToUpper();

            // Ścieżka do pliku z nagraniem czasownika
            newResource.VerbSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Ścieżki do obrazów
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


            return newResource;
        }
    }
}