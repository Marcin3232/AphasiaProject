using System;
using System.Collections.Generic;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise32
{
    public class Exercise32ResourcesList
    {
        private const string DirectoryName = "Exercise32";

        private List<Exercise32LearningResources> exercise32LearningResourcesList = null;
        private List<Exercise32RepeatingResources> exercise32RepeatingResourcesList = null;

        public Exercise32ResourcesList()
        {
            exercise32LearningResourcesList = new List<Exercise32LearningResources>();
            exercise32RepeatingResourcesList = new List<Exercise32RepeatingResources>();

            string directoryName = DirectoryName;

            string learningDirectoryName = string.Format(@"{0}\{1}", directoryName, "LearningSubstageResources");
            string[] pathToLearningFolders = SourceHelper.GetPathToResourceFolders(learningDirectoryName);
            GetLearningData(pathToLearningFolders);

            string repeatingDictionaryName = string.Format(@"{0}\{1}", directoryName, "RepeatingSubstageResources");
            string[] pathToRepeatingFolders = SourceHelper.GetPathToResourceFolders(repeatingDictionaryName);
            GetRepeatingData(pathToRepeatingFolders);

        }

        private void GetLearningData(string[] pathToFolders)
        {

            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderWords = pathToFolders[i];
                var newPairOfWords = Exercise32LearningResources.CreateExercise32LearningResource(pathToFolderWords);

                exercise32LearningResourcesList.Add(newPairOfWords);
            }
        }

        private void GetRepeatingData(string[] pathToFolders)
        {

            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSyllables = pathToFolders[i];
                var newResource = Exercise32RepeatingResources.CreateExercise32RepeatingResources(pathToFolderSyllables);

                exercise32RepeatingResourcesList.Add(newResource);
            }
        }

        public List<Exercise32LearningResources> GetRandomLearningValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise32LearningResourcesList);
        }

        public List<Exercise32RepeatingResources> GetRandomRepeatingValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise32RepeatingResourcesList);
        }
    }
}
