using ExerciseResource.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExerciseResource.Models.Exercise19
{
    public struct Exercise19Resource
    {
        // Lista sylab 
        public List<string> SylabesText { get; private set; }
        public List<string> SylabesSoundSrc { get; private set; }

        // Tablica obrazków
        public string PictureSrc { get; private set; }

        // Słowo z podziałem na sylaby
        public string WordSylabesText { get; private set; }
        public string WordSylabesSoundSrc { get; private set; }

        // Słowo bez podziału na sylaby
        public string WordText { get; private set; }
        public string WordSoundSrc { get; private set; }


        public override string ToString()
        {
            return WordText;
        }

        public static Exercise19Resource CreateNewResource(string pathToFolderSentence)
        {
            string folderName = Path.GetFileName(pathToFolderSentence);
            string[] pathToFiles = Directory.GetFiles(pathToFolderSentence);
            string pathToImgFolder = Directory.GetDirectories(pathToFolderSentence).First(x => x.Split('\\').LastOrDefault() == "img");
            string pathToSylabesSoundFolder = Directory.GetDirectories(pathToFolderSentence).First(x => x.Split('\\').LastOrDefault() == "sylaby");
            string[] pathToSylabesSoundFiles = Directory.GetFiles(pathToSylabesSoundFolder);

            Exercise19Resource newResource = new Exercise19Resource();

            newResource.WordSylabesText = folderName.ToUpper();
            newResource.WordSylabesSoundSrc = SourceHelper.GetSource(pathToFiles, "word_sylabes_sound", "audio/mp3");
            newResource.WordSoundSrc = SourceHelper.GetSource(pathToFiles, "word_sound", "audio/mp3");

            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            string[] sylabes = folderName.ToUpper().Split('-');
            newResource.SylabesText = sylabes.ToList();
            newResource.WordText = CreateWordText(sylabes);
            newResource.SylabesSoundSrc = CreateSylabesSoundSrc(pathToSylabesSoundFiles, sylabes);

            return newResource;
        }

        private static List<string> CreateSylabesSoundSrc(string[] pathToSylabesSoundFiles, string[] sylabes)
        {
            List<string> sylabesSrc = new List<string>();
            for (int i = 1; i <= sylabes.Length; i++)
            {
                sylabesSrc.Add(SourceHelper.GetSource(pathToSylabesSoundFiles,
                    string.Format("sound{0}", i), "audio/mp3"));
            }
            return sylabesSrc;
        }

        private static string CreateWordText(string[] sylabes)
        {
            string word = "";
            foreach (var sylabe in sylabes)
            {
                word += sylabe;
            }
            return word;
        }
    }
}
