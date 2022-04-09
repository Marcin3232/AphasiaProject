using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Utils
{
    public class PanelMatchNormalizer
    {
        public static List<PanelMatchModel> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            List<PanelMatchModel> model = new List<PanelMatchModel>();

            switch (exerciseTaskId)
            {
                case "08":
                    return Get08(resource);
                default:
                    return model;
            }
        }

        private static List<PanelMatchModel> Get08(dynamic resource)
        {
            var model = new List<PanelMatchModel>();
            List<Exercise08Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise08Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelMatchModel()
                {
                    Word = x.Verb,
                    WordSound = x.VerbSoundSrc,
                    Picture = x.PictureSrc,
                });
            });
            return model;
        }
    }
}
