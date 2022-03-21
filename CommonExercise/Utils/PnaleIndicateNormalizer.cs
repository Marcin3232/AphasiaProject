using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PnaleIndicateNormalizer
    {
        public static List<PanelIndicateModel> Get(string exerciseTaskId, dynamic resource)
        {
            List<PanelIndicateModel> model = new List<PanelIndicateModel>();

            switch (exerciseTaskId)
            {
                case "01":
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
                default:
                    return model;
            }
        }
    }
}