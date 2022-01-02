using System;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise18
{
    public struct Exercise18Resource
    {
        public Sentence BasicSentence { get; private set; }

        public Sentence VariedSentence { get; private set; }

        public string[] PicturesSrcs { get; private set; }

        public static Exercise18Resource CreateNewResource(string pathToSentenceTemplateDirectory, string[] templatesPaths,
            string variedSentenceTemplate, string noun)
        {
            // Scieżka do folderu z obrazkami
            string pathToImgFolder = Directory
                .GetDirectories(noun)
                .First();

            // Scieżka do folderu ze ścieżkami dźwiękowymi
            string pathToSoundDirectory = Directory
                .GetDirectories(noun)
                .Last();

            // Nazwa rzeczownika ściągnięta z folderu
            string nounName = Path.GetFileName(noun).ToUpper();

            // Scieżki do plików mp3
            string[] pathsToSoundFiles = Directory.GetFiles(pathToSoundDirectory);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToSentenceTemplateDirectory).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = string.Format("{0}.{1}", currentTemplateDirectoryName, nounName);
            Exercise18Resource newExercise18Resource = new Exercise18Resource();

            var resxManager = SourceHelper.GetResxFile("Exercise18", resxLocation, "varied");

            // Pierwsze zdanie
            string basicWordSound = SourceHelper.GetSource(pathsToSoundFiles, "basic", "audio/mp3");
            string basicSentenceSound = SourceHelper.GetSource(templatesPaths, "basic_sentence_template", "audio/mp3");
            string basicWord = nounName;
            string basicSentence = "TO JEST {0}.";

            // Drugie zdanie 
            string variedWordSound = SourceHelper.GetSource(pathsToSoundFiles, "varied", "audio/mp3");
            string variedSentenceSound = SourceHelper.GetSource(templatesPaths, "varied_sentence_template", "audio/mp3");
            string variedWord = resxManager.GetString("Varied", CultureInfo.CurrentCulture);
            string variedSentence = variedSentenceTemplate;

            // Utworzenie obiektów przekazywanych do ćwiczenia
            newExercise18Resource.BasicSentence = new Sentence(basicSentence, basicWord, basicSentenceSound, basicWordSound);
            newExercise18Resource.VariedSentence = new Sentence(variedSentence, variedWord, variedSentenceSound, variedWordSound);

            // Obrazek
            newExercise18Resource.PicturesSrcs = SourceHelper.GetSource(pathToImgFolder);

            return newExercise18Resource;
        }

        public struct Sentence
        {
            public string SentenceTemplate { get; private set; }
            public string WordToFill { get; private set; }
            public string SentenceSoundSrc { get; private set; }
            public string WordToFillSoundSrc { get; private set; }

            public string FilledSentence
            {
                get
                {
                    return string.Format(SentenceTemplate, WordToFill);
                }
            }

            public string EmptySentence
            {
                get
                {
                    return string.Format(SentenceTemplate, "________");
                }
            }

            public Sentence(string sentenceTemplate,
                string wordToFill,
                string sentenceSoundPath,
                string wordToFillSoundPath)
                : this()
            {
                SentenceTemplate = sentenceTemplate;
                WordToFill = wordToFill;
                SentenceSoundSrc = sentenceSoundPath;
                WordToFillSoundSrc = wordToFillSoundPath;
            }
        }
    }
}