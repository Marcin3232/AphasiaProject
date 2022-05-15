using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;
using static CommonExercise.ExerciseResourceProjection.PanelOption2Model;

namespace CommonExercise.Utils
{
    public class PanelOption2Normalizer
    {
        public static List<PanelOption2Model> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            List<PanelOption2Model> model = new List<PanelOption2Model>();

            switch (exerciseTaskId)
            {
                case "14":
                    return Get14(resource, repeat, model);
                default:
                    return model;
            }
        }

        private static List<PanelOption2Model> Get14(dynamic resource, int repeat, List<PanelOption2Model> model)
        {
            List<Exercise14Resource> tempList = ExerciseResourceConverter
                .ExerciseResource<Exercise14Resource>(resource);
            tempList.ForEach(x =>
            {
                var tempDescList = new List<DescModel>();
                x.Verbs.ForEach(y => tempDescList.Add(new DescModel()
                {
                    Text = y.VerbText,
                    TextPictureSrc = y.VerbPictureSrc,
                    TextSoundSrc = y.VerbSoundSrc,
                }));

                model.Add(new PanelOption2Model()
                {
                    MainText = x.NounSentence,
                    PictureSrc = x.PictureSrc,
                    MainSoundSrc = x.NounSoundSrc,
                    MainSentenceSoundSrc = x.NounSentenceSoundSrc,
                    MainInstructionSoundSrc = x.NounInstructionSoundSrc,
                    DescModels = tempDescList,
                });
            });
            return MultiplierList.Multiply<PanelOption2Model>(model, repeat);
        }
    }
}
