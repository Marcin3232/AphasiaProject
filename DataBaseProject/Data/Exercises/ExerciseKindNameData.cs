using CommonExercise.Enums;
using DataBaseProject.Models.Exercise;
using System.Collections.Generic;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseKindNameData
    {
        public List<ExerciseKindNameModel> GetFilled() => CreateList();
        public ExerciseKindNameModel GetKindName(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseKindNameModel> CreateList()
        {
            var temp = new List<ExerciseKindNameModel>();
            temp.Add(Create(1, (int)ExerciseKind.ListenAndRemember, "Posłuchaj i Zapamiętaj", "...", "sound/instructions/listen_and_remember"));
            temp.Add(Create(2, (int)ExerciseKind.Repeat, "Powtórz", "...", "sound/instructions/repeat"));
            temp.Add(Create(3, (int)ExerciseKind.Indicate, "Wskaż", "...", "sound/instructions/point"));
            temp.Add(Create(4, (int)ExerciseKind.Naming, "Nazwij", "...", "sound/instructions/name"));
            temp.Add(Create(5, (int)ExerciseKind.PractiseWithMe, "Ćwicz ze mną", "...", "sound/instructions/practise_with_me"));
            temp.Add(Create(6, (int)ExerciseKind.CountToTen, "Liczymy do dziesięciu", "...", "sound/instructions/count_to_ten"));
            temp.Add(Create(7, (int)ExerciseKind.RepeatAfterEachItem, "Powtórz po każdym elemencie", "...", "sound/instructions/repeat_each_element"));
            temp.Add(Create(8, (int)ExerciseKind.ArrangeInTurn, "Ułóż po kolei", "...", "sound/instructions/place_in_order"));
            temp.Add(Create(9, (int)ExerciseKind.DaysOfWeek, "Dni tygodnia", "...", "sound/instructions/week_days"));
            temp.Add(Create(10, (int)ExerciseKind.Month, "Miesiące", "...", "sound/instructions/month"));
            return temp;
        }

        private ExerciseKindNameModel Create(int id, int kind, string name, string desc, string soundSrc)
            => new ExerciseKindNameModel()
            {
                Id = id,
                Kind = kind,
                Name = name,
                Description = desc,
                SoundSrc = soundSrc
            };

    }
}
