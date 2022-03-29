using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PanelEnumerationNormalizer
    {
        public static Dictionary<int,List<PanelEnumerationModel>> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            var model = new List<PanelEnumerationModel>();

            switch (exerciseTaskId)
            {
                case "05":
                    return Get05_33_34(exerciseTaskId,resource,repeat,model);
                case "33":
                    return Get05_33_34(exerciseTaskId, resource, repeat, model);
                case "34":
                    return Get05_33_34(exerciseTaskId, resource, repeat, model);
                default:
                    return new Dictionary<int, List<PanelEnumerationModel>>();
            }
        }

        private static Dictionary<int, List<PanelEnumerationModel>> Get05_33_34(string exerciseTaskId,
            dynamic resource, int repeat, List<PanelEnumerationModel> model)
        {
            List<Exercise05_33_34Resource> tempList = ExerciseResourceConverter.
                ExerciseResource<Exercise05_33_34Resource>(resource);
            tempList.ForEach(temp => model.Add(new PanelEnumerationModel()
            {
                Text = temp.Text,
                Number = temp.Number,
                SoundSrc = temp.SoundSrc,
            }));

            return MultiplierDictionary.Multiply<List<PanelEnumerationModel>>(model, repeat);
        }
    }
}
