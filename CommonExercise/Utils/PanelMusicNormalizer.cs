using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PanelMusicNormalizer
    {
        public static List<PanelMusicModel> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            switch (exerciseTaskId)
            {
                case "42":
                    return Get42(resource, repeat);
                default:
                    return new List<PanelMusicModel>();
            }
        }

        private static List<PanelMusicModel> Get42(dynamic resource, int repeat)
        {
            var model = new List<PanelMusicModel>();
            List<Exercise42Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise42Resource>(resource);

            var srcList = new List<SoundSrcExtension>();

            tempList.ForEach(x =>
            {
                x.SoundSrcs.ForEach(src => srcList.Add(new SoundSrcExtension()
                {
                    SoundSrc = src,
                    IsCorrect = false
                }));
                model.Add(new PanelMusicModel()
                {
                    SoundSrcList = srcList,
                    Category = x.Category,
                });
            });

            return MultiplierList.Multiply<PanelMusicModel>(model, repeat);
        }
    }
}
