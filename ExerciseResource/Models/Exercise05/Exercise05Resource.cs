using ExerciseResource.Helpers;
using System.IO;

namespace ExerciseResource.Models.Exercise05
{
    public struct Exercise05Resource
    {
        public string Text { get; private set; }
        public int Number { get; private set; }
        public string SoundSrc { get; private set; }

        public override string ToString()
        {
            return Text;
        }

        public static Exercise05Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);

            Exercise05Resource newResource = new Exercise05Resource();

            string[] texts = folderName.ToUpper().Split();
            newResource.Number = int.Parse(texts[0]);
            newResource.Text = texts[1];

            newResource.SoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            return newResource;
        }
    }
}
