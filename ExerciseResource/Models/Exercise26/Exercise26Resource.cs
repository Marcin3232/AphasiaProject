using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise26
{
    public struct Exercise26Resource
    {
        public string Text { get; private set; }

        public string TextSoundScr { get; private set; }
        public string NounSoundScr { get; private set; }
        public string VerbSoundScr { get; private set; }

        public string[] Words { get; private set; }

        public string PictureSrc { get; private set; }


        public override string ToString()
        {
            return Text;
        }

        public static Exercise26Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);
            string pathToImgFolder = Directory.GetDirectories(pathToFolderSentence).First();

            Exercise26Resource newSentence = new Exercise26Resource();

            // Zdanie 
            newSentence.Text = folderName;

            // Słowa
            newSentence.Words = folderName.Split();

            // Ścieżka do nagrania zdania
            newSentence.TextSoundScr = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");
            newSentence.NounSoundScr = SourceHelper.GetSource(pathToFiles, "1", "audio/mp3");
            newSentence.VerbSoundScr = SourceHelper.GetSource(pathToFiles, "2", "audio/mp3");

            // Sciezki do zdjec
            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newSentence.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


            return newSentence;
        }
    }
}
