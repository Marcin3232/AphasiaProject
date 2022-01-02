using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise14
{
    public struct Exercise14Resource
    {
        public string NounSentence { get; private set; }
        public string PictureSrc { get; private set; }
        public string NounSoundSrc { get; private set; }
        public string NounSentenceSoundSrc { get; private set; }
        public string NounInstructionSoundSrc { get; private set; }
        public List<Verb> Verbs { get; private set; }

        public override string ToString()
        {
            return NounSentence;
        }

        public static Exercise14Resource CreateNewResource(string pathToFolderNoun)
        {
            string folderName = Path.GetFileName(pathToFolderNoun);
            string[] pathToFiles = Directory.GetFiles(pathToFolderNoun);
            string pathToImgFolder = Directory.GetDirectories(pathToFolderNoun).First(x => x.Split('\\').LastOrDefault() == "img");
            string pathToVerbs = Directory.GetDirectories(pathToFolderNoun).First(x => x.Split('\\').LastOrDefault() == "czasowniki");
            string[] pathsToVerbsSources = Directory.GetDirectories(pathToVerbs);


            Exercise14Resource newResource = new Exercise14Resource();

            newResource.NounSentence = folderName;
            newResource.NounSoundSrc = SourceHelper.GetSource(pathToFiles, "noun", "audio/mp3");
            newResource.NounSentenceSoundSrc = SourceHelper.GetSource(pathToFiles, "noun_sentence", "audio/mp3");
            newResource.NounInstructionSoundSrc = SourceHelper.GetSource(pathToFiles, "noun_instruction", "audio/mp3");

            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            newResource.Verbs = new List<Verb>();
            for (int i = 0; i < pathsToVerbsSources.Length; i++)
            {
                Verb newVerb = Verb.CreateNewVerb(pathsToVerbsSources[i]);
                newResource.Verbs.Add(newVerb);
            }

            return newResource;
        }

        public class Verb
        {
            public string VerbText { get; private set; }
            public string VerbSoundSrc { get; private set; }
            public string VerbPictureSrc { get; private set; }
            public static Verb CreateNewVerb(string verbDirectoryPath)
            {
                Random rand = new Random();
                Verb newVerb = new Verb();
                newVerb.VerbText = Path.GetFileName(verbDirectoryPath);
                string[] pathsToVerbFiles = Directory.GetFiles(verbDirectoryPath);
                newVerb.VerbSoundSrc = SourceHelper.GetSource(pathsToVerbFiles, "sound", "audio/mp3");
                string pathToImgFolder = Directory.GetDirectories(verbDirectoryPath).First();
                string[] picturesSrc = SourceHelper.GetSource(pathToImgFolder);
                newVerb.VerbPictureSrc = picturesSrc[rand.Next(picturesSrc.Length)];
                return newVerb;
            }

        }

    }
}
