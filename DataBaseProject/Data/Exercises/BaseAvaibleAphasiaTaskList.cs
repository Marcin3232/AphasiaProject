using CommonExercise.Enums;
using DataBaseProject.Models.Exercise;
using System.Collections.Generic;
using System.IO;

namespace DataBaseProject.Data.Exercises
{
    public class BaseAvaibleAphasiaTaskList
    {
        private static string FilePath(AphasiaTypes aphasiaTypes)
        {
            switch (aphasiaTypes)
            {
                case AphasiaTypes.MixedAphasia:
                    return "Resources/exerciseAvaibleMixedAphasia.txt";
                case AphasiaTypes.MovementAphasia:
                    return "Resources/exerciseAvaibleMovementAphasia.txt";
                case AphasiaTypes.SensoryAphasia:
                    return "Resources/exerciseAvaibleSensoryAphasia.txt";
                default:
                    return null;
            }
        }

        public static List<AvailableBaseExercise> AvaibleExerciseTaskIdList(AphasiaTypes aphasiaTypes)
        {
            var filePath = FilePath(aphasiaTypes);

            if (!File.Exists(filePath))
                return null;

            var list = new List<AvailableBaseExercise>();
            var linse = File.ReadAllLines(filePath);
            int increment = 1;
            foreach (var line in linse)
            {
                if (string.IsNullOrEmpty(line))
                    break;

                var exerciseTaskId = line.Split(";");
                for (int i = 0; i < exerciseTaskId.Length; i++)
                {
                    list.Add(new AvailableBaseExercise()
                    {
                        AphasiaType = aphasiaTypes,
                        Id = increment,
                        IdExerciseTask = exerciseTaskId[i]
                    });
                    increment++;
                }
            }

            return list;
        }
    }
}
