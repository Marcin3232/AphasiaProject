using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise22
{
    public struct Exercise22Resource
    {
        public string AmbientSoundSrc { get; private set; }
        public string PictureSrc { get; private set; }

        public static Exercise22Resource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            Exercise22Resource newResource = new Exercise22Resource();

            // Ścieżka do pliku z nagraniem 
            newResource.AmbientSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Ścieżki do obrazów
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


            return newResource;
        }
    }
}
