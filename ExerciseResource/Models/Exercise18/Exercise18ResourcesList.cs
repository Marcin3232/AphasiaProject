using System;
using System.Collections.Generic;
using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise18
{
    public class Exercise18ResourcesList
    {
        private const string DirectoryName = "Exercise18";
        private List<Exercise18Resource> exercise18ResourceList = null;

        public Exercise18ResourcesList()
        {
            exercise18ResourceList = new List<Exercise18Resource>();

            string directoryName = DirectoryName;
            string[] pathToFolders = SourceHelper.GetPathToResourceFolders(directoryName);

            GetData(pathToFolders);
        }

        private void GetData(string[] pathToFolders)
        {
            var rand = new Random();
            for (int i = 0; i < pathToFolders.Length; i++)
            {
                string pathToFolderSentence = pathToFolders[i];

                string[] pathsToNounFolder = Directory
               .GetDirectories(pathToFolderSentence);

                // Ścieżki do nagrań szkieletu
                string[] templatesPaths = Directory.GetFiles(pathToFolderSentence);

                // Czynna forma zdania ściągnięta z nazwy folderu
                string variedSentenceTemplate = Path.GetFileName(pathToFolderSentence).ToUpper() + " {0}.";

                // Stworzenie kolejnych szabolnów
                var templates = new List<Exercise18Resource>();
                foreach (string noun in pathsToNounFolder)
                {
                    Exercise18Resource newExercise18Resource = Exercise18Resource.CreateNewResource
                        (pathToFolderSentence, templatesPaths, variedSentenceTemplate, noun);

                    // Dodanie do listy
                    templates.Add(newExercise18Resource);
                }
                // TODO: OPTYMALIZACJA! Losować przed ściągniem zasobów.
                int randomResourceIndex = rand.Next(templates.Count);
                var resource = templates[randomResourceIndex];
                exercise18ResourceList.Add(resource);
            }
        }

        public List<Exercise18Resource> GetValues()
        {
            return new List<Exercise18Resource>(exercise18ResourceList);
        }

        public List<Exercise18Resource> GetRandomValues()
        {
            return RandomResourceHelper.GetRandomValues(exercise18ResourceList);
        }
    }
}
