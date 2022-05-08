using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PanelFindPairGameNormalizer
    {
        public static Dictionary<string, List<PanelFindPairModel>> Get(string exerciseTaskId, dynamic reosurce)
        {
            var model = new Dictionary<string, List<PanelFindPairModel>>();
            switch (exerciseTaskId)
            {
                case "24":
                    return Get24(reosurce, model);
                default:
                    return model;
            }
        }

        private static Dictionary<string, List<PanelFindPairModel>> Get24(dynamic resource,
            Dictionary<string, List<PanelFindPairModel>> model)
        {
            List<Exercise24Resource> tempList = ExerciseResourceConverter.
                ExerciseResource<Exercise24Resource>(resource);

            foreach (var item in tempList)
            {
                var tempCard = new List<PanelFindPairModel>();
                item.Cards.ForEach(card => tempCard.Add(new PanelFindPairModel()
                {
                    Id = card.Id,
                    ImgSrc = card.ImgSrc,
                    Flipped = false
                }));

                model.Add(item.CategoryName, tempCard);
            }
            return model;
        }
    }
}
