using ExerciseResource.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ExerciseResource.Models.Exercise30
{
    public struct Exercise30LearningResource
    {
        public string SimpleOne { get; private set; }
        public string SimpleTwo { get; private set; }
        public string ComplexOne { get; private set; }
        public string ComplexTwo { get; private set; }
        public string Conjunction { get; private set; }

        public string SimpleOneSrc { get; private set; }
        public string SimpleTwoSrc { get; private set; }
        public string ConjunctionSrc { get; private set; }

        public static Exercise30LearningResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise30.LearningResources", resxLocation, "texts");

            Exercise30LearningResource newResource = new Exercise30LearningResource();

            newResource.ComplexOne = resxManager.GetString("complexOne", CultureInfo.CurrentCulture);
            newResource.ComplexTwo = resxManager.GetString("complexTwo", CultureInfo.CurrentCulture);
            newResource.SimpleOne = resxManager.GetString("simpleOne", CultureInfo.CurrentCulture);
            newResource.SimpleTwo = resxManager.GetString("simpleTwo", CultureInfo.CurrentCulture);
            newResource.Conjunction = resxManager.GetString("conjunction", CultureInfo.CurrentCulture);

            newResource.SimpleOneSrc = SourceHelper.GetSource(pathToFiles, "sound_first", "audio/mp3");
            newResource.SimpleTwoSrc = SourceHelper.GetSource(pathToFiles, "sound_second", "audio/mp3");
            newResource.ConjunctionSrc = SourceHelper.GetSource(pathToFiles, "sound_all", "audio/mp3");

            return newResource;
        }
    }

    public struct Exercise30UnderstandingResource
    {
        public string ComplexOne { get; private set; }
        public string ComplexTwo { get; private set; }
        public string Conjunction { get; private set; }

        public string SentenceSrc { get; private set; }

        public static Exercise30UnderstandingResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;

            Exercise30UnderstandingResource newResource = new Exercise30UnderstandingResource();

            var resxManager = SourceHelper.GetResxFile("Exercise30.UnderstandingResources", resxLocation, "texts");

            newResource.ComplexOne = resxManager.GetString("complexOne", CultureInfo.CurrentCulture);
            newResource.ComplexTwo = resxManager.GetString("complexTwo", CultureInfo.CurrentCulture);
            newResource.Conjunction = resxManager.GetString("conjunction", CultureInfo.CurrentCulture);

            newResource.SentenceSrc = SourceHelper.GetSource(pathToFiles, "sound_all", "audio/mp3");

            return newResource;
        }
    }

    public struct Exercise30UsingResource
    {
        public Sentence Beginning { get; private set; }
        public Sentence CorrectAnswer { get; private set; }
        public List<Sentence> EndingsList { get; private set; }

        public static Exercise30UsingResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;

            Exercise30UsingResource newResource = new Exercise30UsingResource();

            var resxManager = SourceHelper.GetResxFile("Exercise30.UsingResources", resxLocation, "texts");

            string beginning = resxManager.GetString("sentence", CultureInfo.CurrentCulture);
            string beginningSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_beginning", "audio/mp3");
            newResource.Beginning = Sentence.CreateSentence(beginning, beginningSoundSrc);

            newResource.EndingsList = new List<Sentence>();

            string correct = resxManager.GetString("correct_answer", CultureInfo.CurrentCulture);
            string correctSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_correct", "audio/mp3");
            newResource.CorrectAnswer = Sentence.CreateSentence(correct, correctSoundSrc);

            newResource.EndingsList.Add(newResource.CorrectAnswer);

            string secondAnswer = resxManager.GetString("second_answer", CultureInfo.CurrentCulture);
            string secondAnswerSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_second", "audio/mp3");
            newResource.EndingsList.Add(Sentence.CreateSentence(secondAnswer, secondAnswerSoundSrc));

            string thirdAnswer = resxManager.GetString("third_answer", CultureInfo.CurrentCulture);
            string thirdAnswerSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_third", "audio/mp3");
            newResource.EndingsList.Add(Sentence.CreateSentence(thirdAnswer, thirdAnswerSoundSrc));

            return newResource;
        }

        public struct Sentence
        {
            public string Text { get; private set; }
            public string SoundSrc { get; private set; }

            public static Sentence CreateSentence(string text, string soundSrc)
            {
                Sentence newSentence = new Sentence();
                newSentence.Text = text;
                newSentence.SoundSrc = soundSrc;

                return newSentence;
            }
        }
    }
}