using ExerciseResource.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExerciseResource.Models.Exercise20
{
    public class Exercise20ResourcesList
    {
        private const string DirectoryName = "Exercise20";

        private List<Exercise20LearningResource> exercise20LearningResourceList = null;
        private List<Exercise20UnderstandingResource> exercise20UnderstandingResourceList = null;
        private List<Exercise20UsingResource> exercise20UsingResourceList = null;

        public Exercise20ResourcesList()
        {
            exercise20LearningResourceList = new List<Exercise20LearningResource>();
            exercise20UnderstandingResourceList = new List<Exercise20UnderstandingResource>();
            exercise20UsingResourceList = new List<Exercise20UsingResource>();

            string directoryName = DirectoryName;

            string learningDictionaryName = string.Format(@"{0}\{1}", directoryName, "LearningResources");
            string[] pathToLearningFolders = SourceHelper.GetPathToResourceFolders(learningDictionaryName);
            GetLearningData(pathToLearningFolders);

            string understandingDictionaryName = string.Format(@"{0}\{1}", directoryName, "UnderstandingResources");
            string[] pathToUnderstandingFolders = SourceHelper.GetPathToResourceFolders(understandingDictionaryName);
            GetUnderstandingData(pathToUnderstandingFolders);

            string usingDictionaryName = string.Format(@"{0}\{1}", directoryName, "UsingResources");
            string[] pathToUsingFolders = SourceHelper.GetPathToResourceFolders(usingDictionaryName);
            GetUsingData(pathToUsingFolders);
        }

        private void GetLearningData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise20LearningResource.CreateNewResource(pathToFolderSentence);

                exercise20LearningResourceList.Add(newsentence);
            }
        }

        private void GetUnderstandingData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise20UnderstandingResource.CreateNewResource(pathToFolderSentence);

                exercise20UnderstandingResourceList.Add(newsentence);
            }
        }

        private void GetUsingData(string[] pathToFolders)
        {
            List<Thing> allThings = new List<Thing>();
            string[] pathToThingsFolders = Directory.GetDirectories(pathToFolders[0]);

            for (int i = 0; i < pathToThingsFolders.Length; i++)
            {
                string pathToThingFolder = pathToThingsFolders[i];
                var newThing = Thing.Create(pathToThingFolder);

                allThings.Add(newThing);
            }

            string[] pathToSentenceFolders = Directory.GetDirectories(pathToFolders[1]);
            for (int i = 0; i < pathToSentenceFolders.Length; i++)
            {
                string pathToFolderSentence = pathToSentenceFolders[i];
                var newsentence = Exercise20UsingResource.CreateNewResource(pathToFolderSentence, allThings);

                exercise20UsingResourceList.Add(newsentence);
            }
        }

        public List<Exercise20LearningResource> GetRandomLearningValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise20LearningResourceList);
        }

        public List<Exercise20UnderstandingResource> GetRandomUnderstandingValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise20UnderstandingResourceList);
        }

        public List<Exercise20UsingResource> GetRandomUsingValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise20UsingResourceList);
        }
    }
}
