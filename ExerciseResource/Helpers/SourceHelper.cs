using System;
using System.IO;
using System.Linq;
using System.Resources;
using System.Reflection;

namespace ExerciseResource.Helpers
{
    public static class SourceHelper
    {

        public static string ResourcePath => @"ExerciseResources";
        private static string ProjectName => @"ExerciseResource";

        public static string[] GetPathToResourceFolders(string directoryName)
        {
            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string path = $"{solutiondir}\\{ProjectName}\\{ResourcePath}\\{directoryName}";

            string[] pathToFolders = Directory.GetDirectories(path);
            return pathToFolders;
        }

        public static string[] GetSource(string pathToImgFolder)
        {
            string name = "picture";
            string type = "image/jpg";

            string[] pathToImgesFile = Directory.GetFiles(pathToImgFolder);
            int coutFile = pathToImgesFile.Length;

            string[] data = new string[coutFile];

            for (int i = 0; i < coutFile; i++)
            {
                data[i] = GetSource(pathToImgesFile, name + (i + 1), type);
            }

            return data;
        }

        public static string GetSource(string[] pathToFiles, string name, string type)
        {
            var data = File.ReadAllBytes(pathToFiles
                .Single(x => Path.GetFileNameWithoutExtension(x) == name));

            string src = string.Format("data:{0};base64,{1}", type,
                Convert.ToBase64String(data));

            return src;
        }

        public static string[] GetSource(string[] pathToFiles, string type)
        {
            string[] src = new string[pathToFiles.Length];
            for (int i = 0; i < pathToFiles.Length; i++)
            {
                var data = File.ReadAllBytes(pathToFiles[i]);

                src[i] = string.Format("data:{0};base64,{1}", type,
                    data);
            }

            return src;
        }

        public static string[] GetSource(string[] pathsToFile)
        {
            string type = "image/jpg";

            int coutFile = pathsToFile.Length;

            string[] srcs = new string[coutFile];
            for (int i = 0; i < coutFile; i++)
            {
                var data = File.ReadAllBytes(pathsToFile[i]);

                srcs[i] = string.Format("data:{0};base64,{1}", type,
                    data);
            }

            return srcs;
        }

        public static ResourceManager GetResxFile(string exerciseName, string folderName, string fileName)
        {
            string str = string.Format("ExerciseResource.ExerciseResources.{0}.{1}.{2}", exerciseName, folderName, fileName);

            ResourceManager rm = new ResourceManager(str, Assembly.GetExecutingAssembly());

            return rm;
        }
    }
}
