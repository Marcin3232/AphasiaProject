using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise12
{
    public struct Exercise12Resource
    {
        public string Name { get; private set; }

        public string NameSoundScr { get; private set; }

        public string TaskSoundScr { get; private set; }

        public string BlobScr { get; private set; }

        public string PictureSrc { get; private set; }
        public string PictureSoundSrc { get; private set; }
        public override string ToString()
        {
            return Name;
        }

        public static Exercise12Resource CreateNewResource(string pathToFolderColor)
        {
            string folderName = Path.GetFileName(pathToFolderColor);
            string[] pathToFiles = Directory.GetFiles(pathToFolderColor);

            string pathToImgFolder = Directory
                .GetDirectories(pathToFolderColor)
                .First();

            Exercise12Resource newResource = new Exercise12Resource();

            // Nazwa koloru
            newResource.Name = folderName.ToUpper();

            // Sciezka do pliku .mp3 z nazwa koloru
            newResource.NameSoundScr = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Sciezka do pliku .mp3 z poleceniem, który kolor nalezy wybrac
            newResource.TaskSoundScr = SourceHelper.GetSource(pathToFiles, "sound_task", "audio/mp3");

            // Sciezka do grafiki kleksa
            newResource.BlobScr = SourceHelper.GetSource(pathToFiles, "blob", "image/jpg");

            // Sciezki do zdjec w danym kolorze
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            // Sciezki do nagran do zdjec w danym kolorze
            newResource.PictureSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_picture", "audio/mp3");

            return newResource;
        }
    }
}

//TODO alternatywa
// -<img src="data:image/jpeg;base64,@Html.Raw(Convert.ToBase64String(Model.VehicleImage))" />