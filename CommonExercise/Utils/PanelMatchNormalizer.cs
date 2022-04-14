﻿using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;

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
                case "12":
                    return Get12(resource);
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

        private static List<PanelMatchModel> Get12(dynamic resource)
        {
            var model = new List<PanelMatchModel>();
            List<Exercise12Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise12Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelMatchModel()
                {
                    Word = x.Name,
                    WordSound = x.NameSoundScr,
                    Desctiption = x.PictureSoundSrc,
                    DescriptionSound = x.PictureSoundSrc,
                    Picture = x.PictureSrc,
                    PictureSecond = x.BlobScr,

                });
            });
            return model;
        }
    }
}
