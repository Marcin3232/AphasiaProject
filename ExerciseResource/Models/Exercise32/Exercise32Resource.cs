using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise32
{
    public struct Exercise32LearningResources
    {
        public string PairOfWordsSoundSrc { get; private set; }

        public List<Word> PairOfWords { get; private set; }

        public static Exercise32LearningResources CreateExercise32LearningResource(string pathToFolder)
        {
            Exercise32LearningResources newResource = new Exercise32LearningResources();
            newResource.PairOfWords = new List<Word>();

            // Foldery ze słowami
            string[] pathsToWords = Directory.GetDirectories(pathToFolder);

            // Ścieżka do nagrania obu słów
            string[] pairOfWordsSoundPath = Directory.GetFiles(pathToFolder);
            newResource.PairOfWordsSoundSrc = SourceHelper.GetSource(pairOfWordsSoundPath, "two_words", "audio/mp3");

            for (int i = pathsToWords.Length - 1; i >= 0; i--)
            {
                Word newWord = Word.CreateNewWord(pathsToWords[i]);
                newResource.PairOfWords.Add(newWord);
            }
            return newResource;
        }

        public class Word
        {
            public string PictureSrc { get; private set; }
            public string SoundSrc { get; private set; }

            public static Word CreateNewWord(string pathToFolderWord)
            {
                Word newWord = new Word();

                string[] soundPaths = Directory.GetFiles(pathToFolderWord);
                newWord.SoundSrc = SourceHelper.GetSource(soundPaths, "sound", "audio/mp3");

                string imgDirectory = Directory.GetDirectories(pathToFolderWord).First();

                var pictureSrcs = SourceHelper.GetSource(imgDirectory);
                newWord.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);


                return newWord;
            }
        }
    }

    public struct Exercise32RepeatingResources
    {
        public string SyllablesSoundSrc { get; private set; }
        public string Relation { get; private set; }

        public static Exercise32RepeatingResources CreateExercise32RepeatingResources(string pathToFolder)
        {
            Exercise32RepeatingResources newResource = new Exercise32RepeatingResources();


            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // Ścieżka do pliku z nagraniem sylab
            newResource.SyllablesSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            // Sprawdzenie czy sylaby są takie same czy inne
            newResource.Relation = GetRelationValue(folderName);

            return newResource;
        }

        private static string GetRelationValue(string folderName)
        {
            string relation;
            string[] syllables = folderName.Split('-');
            if (syllables[0] == syllables[1])
            { relation = "same"; }
            else
            { relation = "different"; }
            return relation;
        }

    }
}