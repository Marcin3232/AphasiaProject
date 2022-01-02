using ExerciseResource.Helpers;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise09
{
    public struct Exercise09Resource
    {
        // Całe zdanie
        public string Sentence { get; private set; }
        // Rzeczownik
        public string Noun { get; private set; }
        // Czasownik
        public string Verb { get; private set; }
        // Tablica obrazków
        public string PictureSrc { get; private set; }

        public string SentenceSoundSrc { get; private set; }
        public string NounSoundSrc { get; private set; }
        public string VerbSoundSrc { get; private set; }

        public string QuestionSoundSrc { get; private set; }


        public override string ToString()
        {
            return Noun;
        }

        public static Exercise09Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);

            string pathToImgFolder = Directory.GetDirectories(pathToFolderSentence)
                .First(x => x.Split('\\').LastOrDefault() == "img");

            Exercise09Resource newResource = new Exercise09Resource();

            newResource.Sentence = folderName.ToUpper();

            string[] sentenceParts = newResource.Sentence.Split();
            newResource.Noun = sentenceParts[0];
            newResource.Verb = sentenceParts[1];

            newResource.SentenceSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");
            newResource.NounSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_noun", "audio/mp3");
            newResource.VerbSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_verb", "audio/mp3");
            newResource.QuestionSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_question", "audio/mp3");

            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


            return newResource;
        }
    }
}
