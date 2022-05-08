using CommonExercise.Enums;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AphasiaClientApp.ExercisePanels.PanelFindPairGameCore
{
    public class PanelExtension
    {
        public static List<PanelFindPairModel> GetCards(Dictionary<string, List<PanelFindPairModel>> panelDict,
            ExercisePhase exercisePhase)
        {
            var memoryCard = GetDataCards(panelDict, exercisePhase);
            var tempList = new List<PanelFindPairModel>();
            tempList.AddRange(memoryCard);

            memoryCard.ForEach(x =>
            {
                tempList.Add(new PanelFindPairModel()
                {
                    Flipped = x.Flipped,
                    Id = x.Id,
                    ImgSrc = x.ImgSrc,
                });
            });
            return tempList.Shuffle();
        }

        private static int GetTileCount(ExercisePhase exercisePhase) => PanelTile.GetCount(exercisePhase);

        private static List<PanelFindPairModel> GetDataCards(Dictionary<string, List<PanelFindPairModel>> panelDict,
            ExercisePhase exercisePhase)
        {
            var panelTileCount = GetTileCount(exercisePhase);

            switch ((ExerciseType)exercisePhase.Type)
            {
                case ExerciseType.FindPairLevelOne:
                    return GetLevelOneTwoThree(panelDict, panelTileCount);
                case ExerciseType.FindPairLevelTwo:
                    return GetLevelOneTwoThree(panelDict, panelTileCount);
                case ExerciseType.FindPairLevelThree:
                    return GetLevelOneTwoThree(panelDict, panelTileCount);
                case ExerciseType.FindPairLevelFour:
                    return GetLevelFour(panelDict, panelTileCount);
                case ExerciseType.FindPairLevelFive:
                    return GetLevelFive(panelDict, panelTileCount);
                default:
                    return null;
            }
        }

        private static List<PanelFindPairModel> GetLevelOneTwoThree(Dictionary<string, List<PanelFindPairModel>> panelDict, int tileCount)
        {
            var possibleDict = panelDict.Where(x => x.Value.Count >= (tileCount / 2));
            var element = possibleDict.ElementAtOrDefault(new Random().Next(0, possibleDict.Count()));
            var memoryCard = element.Value.Shuffle();
            return memoryCard.GetRange(0, (tileCount / 2));
        }

        private static List<PanelFindPairModel> GetLevelFour(Dictionary<string, List<PanelFindPairModel>> panelDict, int tileCount)
        {
            var indexList = new List<int>();
            var random = new Random();
            int index;
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    index = random.Next(0, panelDict.Count());

                } while (indexList.Contains(index));
                indexList.Add(index);
            }
            var memoryCard = new List<PanelFindPairModel>();
            foreach (var item in indexList)
            {
                var element = panelDict.ElementAtOrDefault(item);
                memoryCard.AddRange(element.Value);
            }

            return memoryCard.Shuffle().GetRange(0, (tileCount / 2));
        }

        private static List<PanelFindPairModel> GetLevelFive(Dictionary<string, List<PanelFindPairModel>> panelDict, int tileCount)
        {
            var memoryCard = new List<PanelFindPairModel>();
            foreach (var item in panelDict.Values)
                memoryCard.AddRange(item);

            return memoryCard.Shuffle().GetRange(0, (tileCount / 2));
        }
    }
}
