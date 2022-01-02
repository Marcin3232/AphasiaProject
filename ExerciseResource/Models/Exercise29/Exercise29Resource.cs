using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise29
{
    public struct Exercise29Resource
    {
        public string Description { get; private set; }
        public string DescriptionSound { get; private set; }
        public List<StoryStep> StorySteps { get; private set; }

        public static Exercise29Resource CreateExercise29Resource(string resourcePath)
        {
            Exercise29Resource resource = new Exercise29Resource();
            int numberOfResources = 4; // TODO: USUNĄĆ
            resource.StorySteps = new List<StoryStep>();

            resource.Description = Path.GetFileName(resourcePath);
            string[] pathToFiles = Directory.GetFiles(resourcePath);
            resource.DescriptionSound = SourceHelper.GetSource(pathToFiles, "description", "audio/mp3");// description.mp3

            //TODO: ten kod potrzebuje refaktoru

            string[] soundAndImageDirectoryPaths = Directory.GetDirectories(resourcePath);

            string imgDirectory = soundAndImageDirectoryPaths.Single(path => Path.GetFileName(path) == "images");
            string sndDirectory = soundAndImageDirectoryPaths.Single(path => Path.GetFileName(path) == "sounds");

            string[] imgPaths = Directory.GetFiles(imgDirectory);
            string[] imgSources = SourceHelper.GetSource(imgPaths);

            string[] sndPaths = Directory.GetFiles(sndDirectory);
            string[] sndSources = SourceHelper.GetSource(sndPaths, "audio/mp3");

            //if (imgPaths.Length != numberOfResources && sndSources.Length != numberOfResources) // TODO: USUNĄĆ
            // { throw new IndexOutOfRangeException(String.Format("Nieprawidłowa liczba zasobów! Po cztery obrazki i zdjęcia! Nazwa folderu: {0}", resource.Description)); }

            for (int i = 0; i < numberOfResources; i++)
            {
                string imgSrc = imgSources[i];
                string sndSrc = sndSources[i];
                resource.StorySteps.Add(StoryStep.CreateStoryStep(imgSrc, sndSrc));
            }

            return resource;
        }

        public struct StoryStep
        {
            public string ImageSrc { get; private set; }
            public string SoundSrc { get; private set; }

            public static StoryStep CreateStoryStep(string imgSrc, string sndSrc)
            {
                StoryStep storyStep = new StoryStep();

                storyStep.ImageSrc = imgSrc;
                storyStep.SoundSrc = sndSrc;

                return storyStep;
            }
        }
    }
}