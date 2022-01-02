using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise34
{
    public struct Exercise34Resource
    {
        public string Text { get; private set; }
        public int Number { get; private set; }
        public string SoundSrc { get; private set; }

        public override string ToString()
        {
            return Text;
        }

        public static Exercise34Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);

            Exercise34Resource newResource = new Exercise34Resource();

            string[] texts = folderName.ToUpper().Split();
            newResource.Number = int.Parse(texts[0]);
            newResource.Text = texts[1];

            newResource.SoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            return newResource;
        }
    }
}
