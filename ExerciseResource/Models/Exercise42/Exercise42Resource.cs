using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise42
{
    public struct Exercise42Resource
    {
        public List<string> SoundSrcs { get; private set; }
        public string Category { get; private set; }

        public static Exercise42Resource CreateExercise42Resource(string categoryPath)
        {
            Exercise42Resource newExercise42Resource = new Exercise42Resource();
            newExercise42Resource.SoundSrcs = new List<string>();

            newExercise42Resource.Category = Path.GetFileName(categoryPath);

            // Ścieżka do nagrań z dźwiękami
            string[] soundPaths = Directory.GetFiles(categoryPath);

            newExercise42Resource.SoundSrcs = SourceHelper.GetSource(soundPaths, "audio/mp3").ToList();

            return newExercise42Resource;
        }


    }

    public struct CopyOfExercise42Resource
    {
        public List<string> SoundSrcs { get; private set; }
        public string Category { get; private set; }

        public static CopyOfExercise42Resource CreateExercise42Resource(string categoryPath)
        {
            CopyOfExercise42Resource newExercise42Resource = new CopyOfExercise42Resource();
            newExercise42Resource.SoundSrcs = new List<string>();

            newExercise42Resource.Category = Path.GetFileName(categoryPath);

            // Ścieżka do nagrań z dźwiękami
            string[] soundPaths = Directory.GetFiles(categoryPath);

            newExercise42Resource.SoundSrcs = SourceHelper.GetSource(soundPaths, "audio/mp3").ToList();

            return newExercise42Resource;
        }


    }
}
