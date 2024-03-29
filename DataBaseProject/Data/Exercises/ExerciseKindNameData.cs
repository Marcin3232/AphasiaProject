﻿using CommonExercise.Enums;
using DataBaseProject.Models.Exercise;
using System.Collections.Generic;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseKindNameData
    {
        public List<ExerciseKindNameModel> GetFilled() => CreateList();
        public ExerciseKindNameModel GetKindName(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseKindNameModel> CreateList()
        {
            var temp = new List<ExerciseKindNameModel>();
            temp.Add(Create(1, (int)ExerciseKind.ListenAndRemember, "Posłuchaj i Zapamiętaj", "...", $"{BasePath()}listen_and_remember"));
            temp.Add(Create(2, (int)ExerciseKind.Repeat, "Powtórz", "...", $"{BasePath()}repeat"));
            temp.Add(Create(3, (int)ExerciseKind.Indicate, "Wskaż", "...", $"{BasePath()}point"));
            temp.Add(Create(4, (int)ExerciseKind.Naming, "Nazwij", "...", $"{BasePath()}name"));
            temp.Add(Create(5, (int)ExerciseKind.PractiseWithMe, "Ćwicz ze mną", "...", $"{BasePath()}practise_with_me"));
            temp.Add(Create(6, (int)ExerciseKind.CountToTen, "Liczymy do dziesięciu", "...", $"{BasePath()}count_to_ten"));
            temp.Add(Create(7, (int)ExerciseKind.RepeatAfterEachItem, "Powtórz po każdym elemencie", "...", $"{BasePath()}repeat_each_element"));
            temp.Add(Create(8, (int)ExerciseKind.ArrangeInTurn, "Ułóż po kolei", "...", $"{BasePath()}place_in_order"));
            temp.Add(Create(9, (int)ExerciseKind.DaysOfWeek, "Dni tygodnia", "...", $"{BasePath()}week_days"));
            temp.Add(Create(10, (int)ExerciseKind.Month, "Miesiące", "...", $"{BasePath()}month"));
            temp.Add(Create(11, (int)ExerciseKind.ReapeatWhatItIs, "Powtórz, co to?", "...", $"{BasePath()}repeat_what_is_it"));
            temp.Add(Create(12, (int)ExerciseKind.IndicateWhere, "Wskaż, gdzie?", "...", $"{BasePath()}point_where"));
            temp.Add(Create(13, (int)ExerciseKind.RepeatWhatHeDoes, "Powtórz, co robi", "...", $"{BasePath()}say_what_does"));
            temp.Add(Create(14, (int)ExerciseKind.SayWhatDoes, "Powiedz, co robi", "...", $"{BasePath()}repeat_what_does"));
            temp.Add(Create(15, (int)ExerciseKind.MatchCaptionToPicture, "Dopasuj podpis do fotografii", "...", $"{BasePath()}match_caption_to_picture"));
            temp.Add(Create(16, (int)ExerciseKind.MatchColorToPhoto, "Dopasuj kolor do zdjęcia", "...", $"{BasePath()}match_color_to_picture"));
            temp.Add(Create(17, (int)ExerciseKind.IndicatePhotosOnWhich, "Wskaż fotografie na której", "...", $"{BasePath()}point_the_picture_where"));
            temp.Add(Create(18, (int)ExerciseKind.NamingWhatPersonPhotoDo, "Nazwij co robi osoba na fotografii", "...", $"{BasePath()}name_what_does_a_person_in_the_picture"));
            temp.Add(Create(19, (int)ExerciseKind.SpeakSeasonName, "Mów ze mną", "...", $"{BasePath()}speak_with_me_season_names"));
            temp.Add(Create(20, (int)ExerciseKind.MatchSignatureToSeason, "Dopasuj podpis do pory roku", "...", $"{BasePath()}match_signature_to_season"));
            temp.Add(Create(21, (int)ExerciseKind.FinishSentecne, "Dokończ zdanie", "...", $"{BasePath()}finish_sentence2"));
            temp.Add(Create(22, (int)ExerciseKind.FindPair, "Znajdź parę", "...", $"{BasePath()}find_couple"));
            temp.Add(Create(23, (int)ExerciseKind.RepeatAndRemember, "Powtórz i zapamiętaj", "...", $"{BasePath()}repeat_and_remember"));
            temp.Add(Create(24, (int)ExerciseKind.SayWhatCanBeDone, "Powiedz, co można zrobić z...", "...", string.Empty));
            temp.Add(Create(25, (int)ExerciseKind.IndicateWhatDoes, "Wskaż, co robi", "...", $"{BasePath()}point_what_does_he_do"));
            temp.Add(Create(26, (int)ExerciseKind.MatchAnswer, "Dopasuj odpowiedź", "...", $"{BasePath()}match_answer"));
            temp.Add(Create(27, (int)ExerciseKind.PointWhere, "Wskaż gdzie", "...", $"{BasePath()}point_where"));
            temp.Add(Create(28, (int)ExerciseKind.MatchTwoTermsWithPhoto, "Dopasuj dwa określenia do fotografii", "...", $"{BasePath()}match_two_definitions_to_photo"));
            temp.Add(Create(29, (int)ExerciseKind.MatchPhotos, "Dopasuj fotografię", "...", $"{BasePath()}match_photo"));
            temp.Add(Create(30, (int)ExerciseKind.IndicateOutWhatDoesNotFit, "Wskaż co nie pasuje", "...", $"{BasePath()}point_what_does_not_fit"));
            return temp;
        }

        private string BasePath() => "sound/instructions/";
        private ExerciseKindNameModel Create(int id, int kind, string name, string desc, string soundSrc)
            => new ExerciseKindNameModel()
            {
                Id = id,
                Kind = kind,
                Name = name,
                Description = desc,
                SoundSrc = soundSrc
            };

    }
}
