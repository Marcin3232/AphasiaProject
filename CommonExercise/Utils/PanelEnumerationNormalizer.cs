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
                    List<Exercise05_33_34Resource> tempList = ExerciseResourceConverter.
                        ExerciseResource<Exercise05_33_34Resource>(resource);
                    tempList.ForEach(temp => model.Add(new PanelEnumerationModel()
                    {
                        Text = temp.Text,
                        Number = temp.Number,
                        SoundSrc = temp.SoundSrc,
                    }));
        
                    return MultiplierDictionary.Multiply<List<PanelEnumerationModel>>(model,repeat);
                default:
                    return new Dictionary<int, List<PanelEnumerationModel>>();
            }
        }

    }
}
