using ExerciseResource.Helpers;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise07
{
    public struct Exercise07Resource
    {
        // Rzeczownik
        public string Noun { get; private set; }
        public string Description { get; private set; }

        public string PictureSrc { get; private set; }


        public string NounSoundSrc { get; private set; }
        public string DescrSoundSrc { get; private set; }

        public string QuestionSoundSrc { get; private set; }

        public override string ToString()
        {
            return Noun;
        }

        public static Exercise07Resource CreateNewResource(string pathToFolderSentence)
        {
            try
            {

                string folderName = Path.GetFileName(pathToFolderSentence);
                string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);

                string pathToImgFolder = Directory.GetDirectories(pathToFolderSentence)
                    .First(x => x.Split('\\').LastOrDefault() == "img");

                Exercise07Resource newResource = new Exercise07Resource();

                newResource.Noun = folderName.ToUpper();
                string[] sentenceParts = newResource.Noun.Split();

                newResource.Noun = sentenceParts[0];
                for (int i = 1; i < sentenceParts.Length; i++)
                {
                    newResource.Description += sentenceParts[i] + " ";
                }
                newResource.Description = newResource.Description.TrimEnd();
                newResource.Description += "...";

                newResource.NounSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_noun", "audio/mp3");
                newResource.DescrSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_description", "audio/mp3");
                //newResource.QuestionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_question", "audio/mp3");
                var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
                newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

                return newResource;
            }
            catch
            {
                throw;
            }
        }
    }
}
