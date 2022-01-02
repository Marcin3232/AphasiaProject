using ExerciseResource.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;

namespace ExerciseResource.Models.Exercise20
{
    public struct Exercise20LearningResource
    {
        public string SoundSrc { get; private set; }
        public char Type { get; private set; }//SentenceType

        public static Exercise20LearningResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise20.LearningResources", resxLocation, "texts");
            string sentenceType = resxManager.GetString("type", CultureInfo.CurrentCulture);

            Exercise20LearningResource newResource = new Exercise20LearningResource();

            newResource.Type = char.Parse(sentenceType);// GetSentenceType(typeSymbol);
            newResource.SoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            return newResource;
        }

        /*
        public static SentenceType GetSentenceType(char typeSymbol)
        {
            switch (typeSymbol)
            {
                case '.':
                    return SentenceType.Declarative;
                case '?':
                    return SentenceType.Interrogative;
                case '!':
                    return SentenceType.Imperative;
                default:
                    throw new NullReferenceException("Podano nieprawidłowy symbol typu zdania.");
            }
        }
         */

        /*
        public enum SentenceType
        {
            Declarative = '.',    // oznajmujące
            Interrogative = '?',  // pytające
            Imperative = '!'     // rozkazujące
        }
         */
    }

    public struct Exercise20UnderstandingResource
    {
        public List<string> Dialogue { get; private set; }
        public string DialogueSoundSrc { get; private set; }

        public string PlaceName { get; private set; }
        public string PlaceSoundSrc { get; private set; }

        public string PlacePictureSrc { get; private set; }

        public static Exercise20UnderstandingResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise20.UnderstandingResources", resxLocation, "dialogue");

            Exercise20UnderstandingResource newResource = new Exercise20UnderstandingResource();
            newResource.Dialogue = new List<string>();

            // Iteracja po wszystkich resources w pliku resx
            ResourceSet resourceSet = resxManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                newResource.Dialogue.Add(entry.Value.ToString());
            }

            newResource.DialogueSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_dialogue", "audio/mp3");
            newResource.PlaceSoundSrc = SourceHelper.GetSource(pathToFiles, "sound_place", "audio/mp3");

            var pictureSrcs = SourceHelper.GetSource(pathToImgFolder);
            newResource.PlacePictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            newResource.PlaceName = folderName.ToUpper();

            return newResource;
        }
    }

    public struct Exercise20UsingResource
    {
        public List<Thing> Answers { get; private set; }
        public Thing CorrectAnswer { get; private set; }

        public string Sentence { get; private set; }
        public string SentenceSoundSrc { get; private set; }

        public static Exercise20UsingResource CreateNewResource(string pathToFolder, List<Thing> allThings)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            // Relatywna ścieżka w projekcie do pliku resx
            string resxLocation = currentTemplateDirectoryName;
            var resxManager = SourceHelper.GetResxFile("Exercise20.UsingResources.zdania", resxLocation, "texts");

            string correctAnswer = resxManager.GetString("correctAnswer", CultureInfo.CurrentCulture);
            string answerTwo = resxManager.GetString("answer_two", CultureInfo.CurrentCulture);
            string answerOne = resxManager.GetString("answer_one", CultureInfo.CurrentCulture);

            Exercise20UsingResource newResource = new Exercise20UsingResource();

            newResource.Sentence = resxManager.GetString("sentence", CultureInfo.CurrentCulture);
            newResource.CorrectAnswer = allThings.Where(x => x.Name == correctAnswer).First();
            newResource.Answers = new List<Thing>();
            newResource.Answers.Add(allThings.Where(x => x.Name == answerOne).First());
            newResource.Answers.Add(allThings.Where(x => x.Name == answerTwo).First());
            newResource.Answers.Add(newResource.CorrectAnswer);
            newResource.Answers = RandomResourceHelper.GetRandomValues(newResource.Answers);
            newResource.SentenceSoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            return newResource;
        }
    }

    public struct Thing
    {
        public string Name { get; private set; }
        public string SoundSrc { get; private set; }

        public string PictureSrc { get; private set; }

        public static Thing Create(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            Thing newThing = new Thing();
            newThing.Name = folderName.ToUpper();

            newThing.SoundSrc = SourceHelper.GetSource(pathToFiles, "sound", "audio/mp3");

            var picturePaths = Directory.GetFiles(pathToImgFolder);
            var pictureSrcs = SourceHelper.GetSource(picturePaths);
            newThing.PictureSrc = RandomResourceHelper.GetRandomPicturePath(pictureSrcs);

            return newThing;
        }
    }
}
