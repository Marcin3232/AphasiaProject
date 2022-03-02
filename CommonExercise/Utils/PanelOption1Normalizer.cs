using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Utils
{
    public class PanelOption1Normalizer
    {
        public static List<PanelOption1Model> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            List<PanelOption1Model> model = new List<PanelOption1Model>();

            switch (exerciseTaskId)
            {
                case "01":

                    List<Exercise01Resource> tempList = ExerciseResourceConverter
                        .ExerciseResource<Exercise01Resource>(resource);
                    tempList.ForEach(x =>
                    {
                        model.Add(new PanelOption1Model()
                        {
                            Word = x.Word,
                            WordSound = x.WordSoundSrc,
                            Picture = x.PicturesSrcs[0],
                        });
                    });
                    return Multiply(model, repeat);
                default:
                    return model;
            }
        }

        private static List<PanelOption1Model> Multiply(List<PanelOption1Model> list, int repeat)
        {
            if (repeat == 1)
                return list;

            var tempList = new List<PanelOption1Model>();

            for (int i = 0; i < repeat; i++)
                tempList.AddRange(list);

            return tempList;
        }
    }
}
