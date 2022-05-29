using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonExercise.Utils
{
    public class PanelMatchSentenceNormalizer
    {
        public static List<PanelMatchSentenceModel> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            var model = new List<PanelMatchSentenceModel>();

            switch (exerciseTaskId)
            {
                case "15":
                    return Get15(resource, repeat);
                default:
                    return model;
            }
        }

        private static List<PanelMatchSentenceModel> Get15(dynamic resource, int repeat)
        {
            var model = new List<PanelMatchSentenceModel>();

            List<Exercise15Resource> tempList = ExerciseResourceConverter
                .ExerciseResource<Exercise15Resource>(resource);

            tempList.ForEach(x =>
            {
                var question = new List<PanelMatchSentenceModel.Expression>();
                var answers = new List<PanelMatchSentenceModel.Expression>();
                var selected = new List<PanelMatchSentenceModel.Expression>();
                var part = new List<string>();

                x.UsingQuestions.ToList().ForEach(x =>
                question.Add(new PanelMatchSentenceModel.Expression()
                {
                    Id = x.Id,
                    Text = x.Text,
                    SoundSrc = x.SoundSrc,
                }));

                x.UsingAnswers.ToList().ForEach(x =>
                {
                    answers.Add(new PanelMatchSentenceModel.Expression()
                    {
                        Id = x.Id,
                        Text = x.Text,
                        SoundSrc = x.SoundSrc,
                        IsShow = true
                    }); ;
                    selected.Add(new PanelMatchSentenceModel.Expression()
                    {
                        Id = x.Id,
                        Text = x.Text,
                        SoundSrc = x.SoundSrc,
                        IsShow = false,
                    });
                });


                x.UsingExpressionParts.ToList().ForEach(x => part.Add(x));

                model.Add(new PanelMatchSentenceModel()
                {
                    PicturesSrcs = x.PicturesSrcs[new Random().Next(0, x.PicturesSrcs.Length)],
                    Main = new PanelMatchSentenceModel.Expression()
                    { Id = x.MainExpression.Id, SoundSrc = x.MainExpression.SoundSrc, Text = x.MainExpression.Text },
                    Wrong = new PanelMatchSentenceModel.Expression()
                    { Id = x.WrongExpression.Id, SoundSrc = x.WrongExpression.SoundSrc, Text = x.WrongExpression.Text },
                    Question = question,
                    Answer = answers,
                    Selected = selected,
                    Part = part,
                });
            });

            return MultiplierList.Multiply<PanelMatchSentenceModel>(model, repeat);
        }
    }
}
