using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise52
{
    public struct Exercise52LearningResource
    {
        public string ShapeName { get; private set; }

        public string ShapePictureSrc { get; private set; }

        public static Exercise52LearningResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            var newResource = new Exercise52LearningResource();

            newResource.ShapeName = folderName;
            var possiblePicturesSrces = SourceHelper.GetSource(pathToImgFolder);
            newResource.ShapePictureSrc = RandomResourceHelper.GetRandomPicturePath(possiblePicturesSrces);

            return newResource;
        }
    }

    public struct Exercise52UnderstandingResource
    {
        public string Trait { get; private set; }

        public string ElementPictureSrc { get; private set; }

        public static Exercise52UnderstandingResource CreateNewResource(string pathToFolder)
        {
            string folderName = Path.GetFileName(pathToFolder);
            string[] pathToFiles = Directory.GetFiles(pathToFolder);
            string pathToImgFolder = Directory.GetDirectories(pathToFolder).First();

            // C#-powa nazwa folderu, w której nie mogą występować spacje
            string currentTemplateDirectoryName = Path.GetFileName(pathToFolder).Replace(' ', '_');

            var newResource = new Exercise52UnderstandingResource();

            newResource.Trait = folderName;
            var possiblePicturesSrces = SourceHelper.GetSource(pathToImgFolder);
            newResource.ElementPictureSrc = RandomResourceHelper.GetRandomPicturePath(possiblePicturesSrces);

            return newResource;
        }
    }
}
