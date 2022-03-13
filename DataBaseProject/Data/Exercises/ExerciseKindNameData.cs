using DataBaseProject.Models.Exercise;
using System.Collections.Generic;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseKindNameData
    {
        public static List<ExerciseKindNameModel> GetFilled() => CreateList();

        private static List<ExerciseKindNameModel> CreateList()
        {
            var temp = new List<ExerciseKindNameModel>();
            temp.Add(new ExerciseKindNameModel() { Id = 1, Kind = 1, Name = "Posłuchaj i Zapamiętaj", Description = "...", SoundSrc = "sound/instructions/listen_and_remember" });
            return temp;
        }
    }
}
