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
            temp.Add(Create(1, 1, "Posłuchaj i Zapamiętaj", "...", "sound/instructions/listen_and_remember"));
            temp.Add(Create(2, 2, "Powtórz", "...", "sound/instructions/repeat"));
            temp.Add(Create(3, 3, "Wskaż", "...", "sound/instructions/point"));
            temp.Add(Create(4, 4, "Nazwij", "...", "sound/instructions/name"));
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
