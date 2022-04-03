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
                    return Get01(resource, repeat, model);
                case "07":
                    return Get07(resource, repeat, model);
                default:
                    return model;
            }
        }

        private static List<PanelOption1Model> Get01(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
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
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get07(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise07Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise07Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Noun,
                    WordSound = x.NounSoundSrc,
                    Picture = x.PictureSrc,
                    Desctiption = x.Description,
                    DescriptionSound = x.DescrSoundSrc,
                    QuestionSoundSrc = x.QuestionSoundSrc,
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }
    }
}
