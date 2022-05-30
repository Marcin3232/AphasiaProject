using CommonExercise.Enums;
using DataBaseProject.Models.Exercise;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseProject.Data.Exercises
{
    public class ExerciseTypeNameData
    {
        public List<ExerciseTypeNameModel> GetFilled() => CreateList();
        public ExerciseTypeNameModel GetTypeName(int id) => GetFilled().FirstOrDefault(x => x.Id == id);
        private List<ExerciseTypeNameModel> CreateList()
        {
            var temp = new List<ExerciseTypeNameModel>();
            temp.Add(Create(1, (int)ExerciseType.SingleImageTextRepeat, "Powtórz", "..."));
            temp.Add(Create(2, (int)ExerciseType.IndicateImage, "Wskaż obrazek", "..."));
            temp.Add(Create(3, (int)ExerciseType.Naming, "Nazwij", "..."));
            temp.Add(Create(4, (int)ExerciseType.Films, "Film", "..."));
            temp.Add(Create(5, (int)ExerciseType.Enumeration, "Wyliczanie", "..."));
            temp.Add(Create(6, (int)ExerciseType.EnumerationRepeat, "Powtórz po kolei", "..."));
            temp.Add(Create(7, (int)ExerciseType.ArrangeInTurn, "Ułóż po kolei", "..."));
            temp.Add(Create(8, (int)ExerciseType.MatchCaptionToPicture, "Dopowanie tekstu do obrazka", "..."));
            temp.Add(Create(9, (int)ExerciseType.MatchImageToImage, "Dopasuj obrazek do obrazka", "..."));
            temp.Add(Create(10, (int)ExerciseType.MusicListen, "Posłuchaj i zapamiętaj", "..."));
            temp.Add(Create(11, (int)ExerciseType.MusicReapeat, "Powtórz odtworzone nagranie", "..."));
            temp.Add(Create(12, (int)ExerciseType.SingleImageThreeSoundTextRepeat, "Powtórz z trzema ścieżkami dźwiekowymi", "..."));
            temp.Add(Create(13, (int)ExerciseType.SingleImageTwoSoundWithBreakTextRepeat, "Powtórz z dwoma ścieżkami dźwiekowymi i z przerwą pomiędzy nimi", ".."));
            temp.Add(Create(14, (int)ExerciseType.NamingWithSound, "Nazwij z odtworzeniem ścieżki dźwiekowej i pojawieniem się tekstu po przerwie", "..."));
            temp.Add(Create(15, (int)ExerciseType.MatchCaptionToPictureCaptionUnderMode, "Dopasowanie tekstu do obrazka tekst pod obraziem", "..."));
            temp.Add(Create(16, (int)ExerciseType.MatchCaptionToPictureWithDescSound, "Dopasowanie tekstu do obrazka z opisem dźwiękowym", "..."));
            temp.Add(Create(17, (int)ExerciseType.FindPairLevelOne, "Znajdź parę poziom 1", "..."));
            temp.Add(Create(18, (int)ExerciseType.FindPairLevelTwo, "Znajdź parę poziom 2", "..."));
            temp.Add(Create(19, (int)ExerciseType.FindPairLevelThree, "Znajdź parę poziom 3", "..."));
            temp.Add(Create(20, (int)ExerciseType.FindPairLevelFour, "Znajdź parę poziom 4", "..."));
            temp.Add(Create(21, (int)ExerciseType.FindPairLevelFive, "Znajdź parę poziom 5", "..."));
            temp.Add(Create(22, (int)ExerciseType.ImageTextAndTextAroundDescWithImage, "Opis przedmiotu, Opis go obrazkami i dźwiekiem", "..."));
            temp.Add(Create(23, (int)ExerciseType.ImageAndTextAroundDescWithImageNamingWithoutText, "Opis przedmiotu, opis obrazkami, nazywanie", "..."));
            temp.Add(Create(24, (int)ExerciseType.ImageAndTextAroundDescWithImageNamingWithoutText, "Dopasuj opis do obrazka, bez przycisku dźwięku", "..."));
            temp.Add(Create(25, (int)ExerciseType.MatchTwoAnswer, "Dopasuj 2 odpowiedzi do obrazka", "..."));
            temp.Add(Create(26, (int)ExerciseType.ThreeImageTextRepeat, "Powtórz 3 określenia", "..."));
            temp.Add(Create(27, (int)ExerciseType.IndicateThreeImage, "Wskaż gdzie pomiędzy 3 obrazkami", "..."));
            temp.Add(Create(28, (int)ExerciseType.MatchTwoTermsToPhoto, "Dopasuj dwa określenia do fotografii", "..."));
            return temp;
        }

        private ExerciseTypeNameModel Create(int id, int type, string name, string desc) => new ExerciseTypeNameModel()
        {
            Id = id,
            Type = type,
            Name = name,
            Description = desc
        };
    }
}
