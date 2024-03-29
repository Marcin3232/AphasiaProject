﻿using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models.ExerciseResource;
using System;
using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class PanelOption1Normalizer
    {
        public static List<PanelOption1Model> Get(string exerciseTaskId, dynamic resource, int repeat)
        {
            List<PanelOption1Model> model = new List<PanelOption1Model>();

            switch (exerciseTaskId)
            {
                case "01":
                    return Get01(resource, repeat, model);
                case "07":
                    return Get07(resource, repeat, model);
                case "08":
                    return Get08(resource, repeat, model);
                case "09":
                    return Get09(resource, repeat, model);
                case "12":
                    return Get12(resource, repeat, model);
                case "13":
                    return Get13(resource, repeat, model);
                case "15":
                    return Get15(resource, repeat, model);
                default:
                    return model;
            }
        }

        private static List<PanelOption1Model> Get01(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise01Resource> tempList = ExerciseResourceConverter
                .ExerciseResource<Exercise01Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Word,
                    WordSound = x.WordSoundSrc,
                    Picture = x.PicturesSrcs[0],
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get07(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise07Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise07Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Noun,
                    WordSound = x.NounSoundSrc,
                    Picture = x.PictureSrc,
                    Description = x.Description,
                    DescriptionSound = x.DescrSoundSrc,
                    QuestionSoundSrc = x.QuestionSoundSrc,
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get08(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise08Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise08Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Verb,
                    WordSound = x.VerbSoundSrc,
                    Picture = x.PictureSrc,
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get09(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise09Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise09Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Noun,
                    WordSound = x.NounSoundSrc,
                    Sentence = x.Sentence,
                    SentenceSoundSrc = x.SentenceSoundSrc,
                    Verb = x.Verb,
                    VerbSoundSrc = x.VerbSoundSrc,
                    QuestionSoundSrc = x.QuestionSoundSrc,
                    FirstSoundSrc = x.SentenceSoundSrc,
                    SecondSoundSrc = x.VerbSoundSrc,
                    FirstText = x.Noun,
                    SecondText = x.Sentence,
                    Picture = x.PictureSrc,
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get12(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise12Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise12Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Name,
                    WordSound = x.NameSoundScr,
                    Picture = x.BlobScr,
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get13(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise13Resource> tempList = ExerciseResourceConverter
                    .ExerciseResource<Exercise13Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.Name,
                    WordSound = x.NameSoundSrc,
                    Sentence = x.SentenceString,
                    SentenceSoundSrc = x.SentenceSoundSrc,
                    Verb = x.Name,
                    VerbSoundSrc = x.NameSoundSrc,
                    FirstSoundSrc = x.SentenceSoundSrc,
                    SecondSoundSrc = x.NameSoundSrc,
                    FirstText = x.SentenceString,
                    SecondText = x.Name,
                    Picture = x.PictureSrc
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }

        private static List<PanelOption1Model> Get15(dynamic resource, int repeat, List<PanelOption1Model> model)
        {
            List<Exercise15Resource> tempList = ExerciseResourceConverter
                .ExerciseResource<Exercise15Resource>(resource);
            tempList.ForEach(x =>
            {
                model.Add(new PanelOption1Model()
                {
                    Word = x.MainExpression.Text,
                    WordSound = x.MainExpression.SoundSrc,
                    Picture = x.PicturesSrcs[new Random().Next(0, x.PicturesSrcs.Length)],
                });
            });
            return MultiplierList.Multiply<PanelOption1Model>(model, repeat);
        }
    }
}
