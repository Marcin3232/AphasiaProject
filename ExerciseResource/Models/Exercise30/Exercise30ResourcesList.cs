using ExerciseResource.Helpers;
using System;
using System.Collections.Generic;

namespace ExerciseResource.Models.Exercise30
{
    public class Exercise30ResourcesList
    {
        private const string DirectoryName = "Exercise30";

        private List<Exercise30LearningResource> exercise30LearningResourceList = null;
        private List<Exercise30UnderstandingResource> exercise30UnderstandingResourceList = null;
        private List<Exercise30UsingResource> exercise30UsingResourceList = null;

        public Exercise30ResourcesList()
        {
            exercise30LearningResourceList = new List<Exercise30LearningResource>();
            exercise30UnderstandingResourceList = new List<Exercise30UnderstandingResource>();
            exercise30UsingResourceList = new List<Exercise30UsingResource>();

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
                var newsentence = Exercise30LearningResource.CreateNewResource(pathToFolderSentence);

                exercise30LearningResourceList.Add(newsentence);
            }
        }

        private void GetUnderstandingData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise30UnderstandingResource.CreateNewResource(pathToFolderSentence);

                exercise30UnderstandingResourceList.Add(newsentence);
            }
        }


        private void GetUsingData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];
                var newsentence = Exercise30UsingResource.CreateNewResource(pathToFolderSentence);

                exercise30UsingResourceList.Add(newsentence);
            }
        }

        public List<Exercise30LearningResource> GetRandomLearningValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise30LearningResourceList);
        }

        public List<Exercise30UnderstandingResource> GetRandomUnderstandingValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise30UnderstandingResourceList);
        }

        public List<Exercise30UsingResource> GetRandomUsingValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise30UsingResourceList);
        }
    }
}
