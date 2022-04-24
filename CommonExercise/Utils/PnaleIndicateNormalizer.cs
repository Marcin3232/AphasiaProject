using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PnaleIndicateNormalizer
    {
        public static List<PanelIndicateModel> Get(string exerciseTaskId, dynamic resource)
        {
            switch (exerciseTaskId)
            {
                case "01":
                    return Get01(resource);
                case "07":
                    return Get07(resource);
                case "08":
                    return Get08(resource);
                case "09":
                    return Get09(resource);
                case "12":
                    return Get12(resource);
                default:
                    return new List<PanelIndicateModel>();
            }
        }

        private static List<PanelIndicateModel> Get01(dynamic resource)
        {
            var model = new List<PanelIndicateModel>();
            List<Exercise01Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise01Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelIndicateModel()
                {
                    Word = x.Word,
                    WordSound = x.WordSoundSrc,
                    WordInstructionSound = x.InstructionSoundSrc,
                    Picture = x.PicturesSrcs
                });
            });
            return model;
        }

        private static List<PanelIndicateModel> Get07(dynamic resource)
        {
            var model = new List<PanelIndicateModel>();
            List<Exercise07Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise07Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelIndicateModel()
                {
                    Word = x.Noun,
                    WordSound = x.NounSoundSrc,
                    WordInstructionSound = x.DescrSoundSrc,
                    Picture = new string[] { x.PictureSrc },
                    Desctiption = x.Description,
                    DescriptionSound = x.DescrSoundSrc,
                    QuestionSoundSrc = x.QuestionSoundSrc,
                });
            });
            return model;
        }

        private static List<PanelIndicateModel> Get08(dynamic resource)
        {
            var model = new List<PanelIndicateModel>();
            List<Exercise08Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise08Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelIndicateModel()
                {
                    Word = x.Verb,
                    WordSound = x.VerbSoundSrc,
                    Picture = new string[] { x.PictureSrc },
                });
            });
            return model;
        }

        private static List<PanelIndicateModel> Get09(dynamic resource)
        {
            var model = new List<PanelIndicateModel>();
            List<Exercise09Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise09Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelIndicateModel()
                {
                    Word = x.Verb,
                    WordSound = x.VerbSoundSrc,
                    Picture = new string[] { x.PictureSrc },
                });
            });
            return model;
        }

        private static List<PanelIndicateModel> Get12(dynamic resource)
        {
            var model = new List<PanelIndicateModel>();
            List<Exercise12Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise12Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelIndicateModel()
                {
                    Word = x.Name,
                    WordSound = x.NameSoundScr,
                    Picture = new string[] { x.BlobScr },
                });
            });
            return model;
        }
    }
}