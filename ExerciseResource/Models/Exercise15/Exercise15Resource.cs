using System;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise15
{
    public struct Exercise15Resource
    {
        public string[] PicturesSrcs { get; private set; }
        public VerbExpression MainExpression { get; private set; }
        public VerbExpression WrongExpression { get; private set; }
        public VerbExpression[] UsingQuestions { get; private set; }
        public VerbExpression[] UsingAnswers { get; private set; }
        public string[] UsingExpressionParts { get; private set; }

        public static Exercise15Resource CreateNewResource(string resourcePath)
        {
            string[] pathToFiles = Directory.GetFiles(resourcePath);

            Exercise15Resource new15Template = new Exercise15Resource();

            VerbExpression[] questions = new VerbExpression[]{ GetUsingQuestion(resourcePath, "first", 0),
            GetUsingQuestion(resourcePath, "second", 1)};
            VerbExpression[] answers = new VerbExpression[]{ GetUsingAnswer(resourcePath, "first", 0),
            GetUsingAnswer(resourcePath, "second", 1)};

            // Źródło obrazka
            new15Template.PicturesSrcs = GetImageSrcs(resourcePath);

            // Pełne zdanie np. "Je obiad w restauracji"
            new15Template.MainExpression = GetMainExpression(resourcePath);

            // Zdanie niepoprawne w UnderstandingStage np. "Je śniadanie z rodziną"
            new15Template.WrongExpression = GetWrongExpression(resourcePath);

            // Części zdania do wklejenia przy składaniu zdania
            new15Template.UsingExpressionParts = GetUsingTextParts(resourcePath);

            // Pytania typu "CO JE?"
            new15Template.UsingQuestions = questions;

            // Odpowiedzi na pytania powyżej
            new15Template.UsingAnswers = answers;

            // Fragmenty zdań umieszczane w ramkach
            new15Template.UsingExpressionParts = GetUsingTextParts(resourcePath);

            return new15Template;
        }

        #region Directory Browsing Methods

        private static string[] GetImageSrcs(string resourcePath)
        {
            string pathToImgFolder = Directory
                .GetDirectories(resourcePath)
                .First(x => x.EndsWith("img"));

            string[] pathsToImgs = Directory.GetFiles(pathToImgFolder);
            string[] imgSources = SourceHelper.GetSource(pathsToImgs, "image/jpg");

            return imgSources;
        }

        private static VerbExpression GetWrongExpression(string resourcePath)
        {
            string type = "audio/mp3";
            string exerciseName = "Exercise15";
            string resxFileName = "wrongExpression";
            VerbExpression wrongExpression;
            string understandingDirectory = Directory.GetDirectories(resourcePath).First(x => x.EndsWith("understanding"));

            string[] pathToSound = Directory.GetFiles(understandingDirectory);
            string soundSrc = SourceHelper.GetSource(pathToSound, type).First();

            string directoryRelativePath = string.Format("{0}.{1}",
                Path.GetFileName(resourcePath),
                Path.GetFileName(understandingDirectory));
            var resx = SourceHelper.GetResxFile(exerciseName, directoryRelativePath, resxFileName);
            string text = resx.GetString("text", System.Globalization.CultureInfo.CurrentCulture);

            wrongExpression = VerbExpression.CreateVerbExpression(text, soundSrc);

            return wrongExpression;
        }

        private static VerbExpression GetMainExpression(string resourcePath)
        {
            string type = "audio/mp3";
            string exerciseName = "Exercise15";
            string resxFileName = "mainExpression";
            VerbExpression mainExpression;

            string[] pathToSounds = Directory.GetFiles(resourcePath);
            string[] pathToSound = pathToSounds.Where(x => x.EndsWith(".mp3")).ToArray();
            string soundSrc = SourceHelper.GetSource(pathToSound, type).First();

            string directoryRelativePath = Path.GetFileName(resourcePath);
            var resx = SourceHelper.GetResxFile(exerciseName, directoryRelativePath, resxFileName);
            string text = resx.GetString("text", System.Globalization.CultureInfo.CurrentCulture);

            mainExpression = VerbExpression.CreateVerbExpression(text, soundSrc);

            return mainExpression;
        }

        private static VerbExpression GetUsingQuestion(string resourcePath, string directoryName, int id)
        {
            string type = "audio/mp3";
            string exerciseName = "Exercise15";
            string fileName = "question";
            VerbExpression questionExpression;
            string[] resourceDirectories = Directory.GetDirectories(resourcePath);
            string usingDirectory = resourceDirectories.First(x => x.EndsWith("using"));
            string[] usingDirectories = Directory.GetDirectories(usingDirectory);
            string expressionDirectory = usingDirectories.First(x => x.EndsWith(directoryName));

            string[] pathToSound = Directory.GetFiles(expressionDirectory).Where(x => x.EndsWith(fileName + ".mp3")).ToArray();
            string soundSrc = SourceHelper.GetSource(pathToSound, type).First();

            string directoryRelativePath = string.Format("{0}.{1}.{2}",
                Path.GetFileName(resourcePath),
                "using",
                directoryName);
            var resx = SourceHelper.GetResxFile(exerciseName, directoryRelativePath, fileName);
            string text = resx.GetString("text", System.Globalization.CultureInfo.CurrentCulture);

            questionExpression = VerbExpression.CreateVerbExpression(text, soundSrc, id);

            return questionExpression;
        }
        // TODO: scalić w jedną metodę przyjmująca filename?
        private static VerbExpression GetUsingAnswer(string resourcePath, string directoryName, int id)
        {
            string type = "audio/mp3";
            string exerciseName = "Exercise15";
            string fileName = "answer";
            VerbExpression questionExpression;
            string[] resourceDirectories = Directory.GetDirectories(resourcePath);
            string usingDirectory = resourceDirectories.First(x => x.EndsWith("using"));
            string[] usingDirectories = Directory.GetDirectories(usingDirectory);
            string expressionDirectory = usingDirectories.First(x => x.EndsWith(directoryName));

            string[] pathToSound = Directory.GetFiles(expressionDirectory).Where(x => x.EndsWith(fileName + ".mp3")).ToArray();
            string soundSrc = SourceHelper.GetSource(pathToSound, type).First();

            string directoryRelativePath = string.Format("{0}.{1}.{2}",
                 Path.GetFileName(resourcePath),
                 "using",
                 directoryName);
            var resx = SourceHelper.GetResxFile(exerciseName, directoryRelativePath, fileName);
            string text = resx.GetString("text", System.Globalization.CultureInfo.CurrentCulture);

            questionExpression = VerbExpression.CreateVerbExpression(text, soundSrc, id);

            return questionExpression;
        }

        private static string[] GetUsingTextParts(string resourcePath)
        {
            string exerciseName = "Exercise15";
            string resxFileName = "sentenceParts";

            string directoryRelativePath = string.Format("{0}.{1}", Path.GetFileName(resourcePath), "using");
            var resx = SourceHelper.GetResxFile(exerciseName, directoryRelativePath, resxFileName);
            string[] parts = {resx.GetString("partOne", System.Globalization.CultureInfo.CurrentCulture),
                             resx.GetString("partTwo", System.Globalization.CultureInfo.CurrentCulture),
                             resx.GetString("partThree", System.Globalization.CultureInfo.CurrentCulture)};

            return parts;
        }

        #endregion Directory Browsing Methods

        public string GetRandomPicturePath()
        {
            return RandomResourceHelper.GetRandomPicturePath(PicturesSrcs);
        }

        public struct VerbExpression
        {
            public string Text { get; private set; }
            public string SoundSrc { get; private set; }
            public int ID { get; private set; }

            public static VerbExpression CreateVerbExpression(string text, string soundSrc)
            {
                var newExpression = new VerbExpression();

                newExpression.Text = text;
                newExpression.SoundSrc = soundSrc;

                return newExpression;
            }

            public static VerbExpression CreateVerbExpression(string text, string soundSrc, int id)
            {
                var newExpression = new VerbExpression();

                newExpression.Text = text;
                newExpression.SoundSrc = soundSrc;
                newExpression.ID = id;

                return newExpression;
            }
        }
    }
}