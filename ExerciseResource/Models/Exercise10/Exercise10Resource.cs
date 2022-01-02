using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise10
{
    public struct Exercise10Resource
    {
        public string FullSentenceSound { get; private set; }

        public List<Sentence> Contradictions { get; private set; }

        public Sentence MainSentence
        {
            get { return Contradictions[0]; }
        }

        public Sentence OppositeSentence
        {
            get { return Contradictions[1]; }
        }

        public static Exercise10Resource CreateExercise10Resource(string directoryPath)
        {
            Exercise10Resource newExercise10Resource = new Exercise10Resource();
            newExercise10Resource.Contradictions = new List<Sentence>();

            // Foldery ze zdaniami oraz ich przeciwnościami
            string[] pathsSentences = Directory
                .GetDirectories(directoryPath);

            // Ścieżka do nagrania z całym zdaniem
            string[] fullSentenceSoundPath = Directory.GetFiles(directoryPath);
            string wordSrc = SourceHelper.GetSource(fullSentenceSoundPath, "full_context", "audio/mp3");
            newExercise10Resource.FullSentenceSound = wordSrc;

            // ustawienie folderow jest "opposite" i "word" jest odwrotnie niż powinno przez alfabet
            pathsSentences = pathsSentences.Reverse().ToArray();

            foreach (string contradictionPath in pathsSentences)
            {
                Sentence newContradiction = Sentence.CreateNewSentence(contradictionPath);
                newExercise10Resource.Contradictions.Add(newContradiction);
            }

            return newExercise10Resource;
        }

        public class Sentence // Moze inna nazwa?
        {
            public string ImageSrc { get; private set; }
            private string[] ContextParts { get; set; }
            public string WordToFill { get; private set; }
            public string ContextSound { get; private set; }
            public string WordSound { get; private set; }
            public string ContextBeforeWord { get { return ContextParts[0]; } }
            public string ContextAfterWord { get { return ContextParts[1]; } }

            public static Sentence CreateNewSentence(string directoryPath)
            {
                Sentence newSentence = new Sentence();
                Random rand = new Random(); // być może lepiej stworzyć obiekt anonimowo?

                // Zdobycie ścieżki do folderu z obrazami
                string imgDirectory = Directory.GetDirectories(directoryPath).First();

                // Zdobycie ścieżek do dźwięków
                string[] soundPaths = Directory.GetFiles(directoryPath);

                // Przerobienie dźwięków na sourcy
                string wordSrc = SourceHelper.GetSource(soundPaths, "word", "audio/mp3");
                string contextSrc = SourceHelper.GetSource(soundPaths, "context", "audio/mp3");

                // Zdobycie pathów obrazków, przerobienie ich na sourcy i wylosowanie jednego z nich
                string[] imgSrcs = SourceHelper.GetSource(imgDirectory);
                string imgSrc = imgSrcs[rand.Next(imgSrcs.Length)];

                // Wyznaczenie relatywnej ścieżki do pliku resx
                string[] diretoryNames = directoryPath.Split(Path.DirectorySeparatorChar);
                string categoryName = diretoryNames[diretoryNames.Length - 3];
                string resourceName = diretoryNames[diretoryNames.Length - 2];
                string oppositeOrWord = diretoryNames[diretoryNames.Length - 1];
                string relativePathToResxFile = string.Format("{0}.{1}.{2}", categoryName, resourceName, oppositeOrWord);

                // Otwarcie pliku resx. Uwaga: konieczne stałe nazwy plików i zmiennych w nich                
                var resxManager = SourceHelper.GetResxFile("Exercise10", relativePathToResxFile, "text");
                string contextBefore = resxManager.GetString("contextBefore", CultureInfo.CurrentCulture);
                string contextAfter = resxManager.GetString("contextAfter", CultureInfo.CurrentCulture);
                string[] contextParts = new string[] { contextBefore, contextAfter };
                string wordToFill = resxManager.GetString("word", CultureInfo.CurrentCulture);

                newSentence.ImageSrc = imgSrc;
                newSentence.WordSound = wordSrc;
                newSentence.ContextSound = contextSrc;
                newSentence.WordToFill = wordToFill;
                newSentence.ContextParts = contextParts;

                return newSentence;
            }
        }
    }
}
