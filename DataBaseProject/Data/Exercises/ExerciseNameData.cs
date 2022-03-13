using DataBaseProject.Models.Const;
using DataBaseProject.Models.Exercise;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataBaseProject.Data.Exercises
{
    internal class ExerciseNameData
    {
        private static readonly string filePath = "Resources/exerciseList.txt";

        private bool VerifyFileExist() => File.Exists(filePath);

        public static List<ExerciseNameModel> ExerciseNameList()
        {
            if (!File.Exists(filePath))
                return null;

            var list = new List<ExerciseNameModel>();
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            int increment = 1;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    break;
                var exerciseName = new ExerciseNameModel()
                {
                    Id = increment,
                    ImageSrc = $"{ImageBasicSrc.ImageExerciseIconsSrc}{line.Split('\"', StringSplitOptions.None)[1].ToLower()}",
                    Name = line.Split("//", StringSplitOptions.None)[1],
                    IdExerciseTask = Regex.Match(line.Split('\"', StringSplitOptions.None)[1], @"\d+").Value,
                    Description = line,
                };
                increment++;
                list.Add(exerciseName);
            }
            return list;
        }
    }
}
