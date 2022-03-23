using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;
using System.Linq;

namespace CommonExercise.Utils
{
    public class PanelFilmNormalizer
    {
        public static PanelFilmModel Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            PanelFilmModel model = new PanelFilmModel();

            switch (exerciseTaskId)
            {
                case "02":
                    List<Exercise02Resource> tempList = ExerciseResourceConverter.
                        ExerciseResource<Exercise02Resource>(resource);

                    var temp = tempList.FirstOrDefault();
                    model = new PanelFilmModel()
                    {
                        VideosSrc = CreateDictEx2(temp, repeat),
                        FullSentenceSound = temp.FullSentenceSound,

                    };
                    return model;
                default:
                    return model;
            }
        }

        private static Dictionary<int, List<string>> CreateDictEx2(Exercise02Resource resource, int repeat) =>
            new Dictionary<int, List<string>>()
            {
                {1,MultiplierList.Multiply<string>(resource.PartOneVideoSrcs,repeat) },
                {2,MultiplierList.Multiply<string>(resource.PartTwoVideoSrcs,repeat) },
                {4,MultiplierList.Multiply<string>(resource.PartThreeVideoSrcs,repeat) },
            };
    }
}
