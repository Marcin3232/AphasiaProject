using System;
using System.Collections.Generic;
using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise52
{
    public class Exercise52ResourcesList
    {
        private const string DirectoryName = "Exercise52";

        private List<List<Exercise52LearningResource>> exercise52LearningResourceList = null;
        private List<List<Exercise52UnderstandingResource>> exercise52UnderstandingResourceList = null;

        public Exercise52ResourcesList()
        {
            exercise52LearningResourceList = new List<List<Exercise52LearningResource>>();
            exercise52UnderstandingResourceList = new List<List<Exercise52UnderstandingResource>>();

            string learningDictionaryName = string.Format(@"{0}\{1}", DirectoryName, "LearningResources");
            string[] pathToLearningFolders = SourceHelper.GetPathToResourceFolders(learningDictionaryName);
            GetLearningData(pathToLearningFolders);

            string understandingDictionaryName = string.Format(@"{0}\{1}", DirectoryName, "UnderstandingResources");
            string[] pathToUnderstandingFolders = SourceHelper.GetPathToResourceFolders(understandingDictionaryName);
            GetUnderstandingData(pathToUnderstandingFolders);
        }

        private void GetLearningData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderImageType = pathToFolders[i];
                string[] pathsToResourcesFolder = Directory.GetDirectories(pathToFolderImageType);

                var imageTypes = new List<Exercise52LearningResource>();

                for (int j = 0; j < pathsToResourcesFolder.Length; j++)
                {
                    var newImage = Exercise52LearningResource.CreateNewResource(pathsToResourcesFolder[j]);
                    imageTypes.Add(newImage);
                }

                exercise52LearningResourceList.Add(imageTypes);
            }
        }

        private void GetUnderstandingData(string[] pathToFolders)
        {
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderImageType = pathToFolders[i];
                string[] pathsToResourcesFolder = Directory.GetDirectories(pathToFolderImageType);

                var imageTypes = new List<Exercise52UnderstandingResource>();

                for (int j = 0; j < pathsToResourcesFolder.Length; j++)
                {
                    var newImage = Exercise52UnderstandingResource.CreateNewResource(pathsToResourcesFolder[j]);
                    imageTypes.Add(newImage);
                }

                exercise52UnderstandingResourceList.Add(imageTypes);
            }
        }

        public List<List<Exercise52LearningResource>> GetRandomLearningValues()
        {
            for (int i = 0; i < exercise52LearningResourceList.Count; i++)
            {
                exercise52LearningResourceList[i] = RandomResourceHelper
                    .GetRandomValues(exercise52LearningResourceList[i]);
            }
            return exercise52LearningResourceList;
        }

        public List<List<Exercise52UnderstandingResource>> GetRandomUnderstandingValues()
        {
            for (int i = 0; i < exercise52UnderstandingResourceList.Count; i++)
            {
                exercise52UnderstandingResourceList[i] = RandomResourceHelper
                    .GetRandomValues(exercise52UnderstandingResourceList[i]);
            }
            return exercise52UnderstandingResourceList;
        }

    }
}
