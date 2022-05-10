using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Enums
{
    public enum ExerciseKind
    {
        [Display(Name = "Listen and remember")]
        ListenAndRemember = 1,
        [Display(Name = "Repeat")]
        Repeat = 2,
        [Display(Name = "Indicate")]
        Indicate = 3,
        [Display(Name = "Naming")]
        Naming = 4,
        [Display(Name = "Practise with me")]
        PractiseWithMe = 5,
        [Display(Name = "We count to ten")]
        CountToTen = 6,
        [Display(Name = "Repeat after each item")]
        RepeatAfterEachItem = 7,
        [Display(Name = "Arrange in turn")]
        ArrangeInTurn = 8,
        [Display(Name = "Days of the week")]
        DaysOfWeek = 9,
        [Display(Name = "Month")]
        Month = 10,
        [Display(Name = "Reapeat, what it is")]
        ReapeatWhatItIs = 11,
        [Display(Name = "Indicate where")]
        IndicateWhere = 12,
        [Display(Name = "Repeat what he does")]
        RepeatWhatHeDoes = 13,
        [Display(Name ="Say what does")]
        SayWhatDoes = 14,
        [Display(Name = "Match caption to picture")]
        MatchCaptionToPicture=15,
        [Display(Name = "Match the color to the photo")]
        MatchColorToPhoto = 16,
        [Display(Name = "Indicate the photos on which")]
        IndicatePhotosOnWhich = 17,
        [Display(Name = "Name what the person in the photo is doing")]
        NamingWhatPersonPhotoDo = 17,
        [Display(Name = "Speak with me season names")]
        SpeakSeasonName = 18,
        [Display(Name ="Match signature to season")]
        MatchSignatureToSeason = 19,
        [Display(Name ="Finish sentence")]
        FinishSentecne = 20,
        [Display(Name = "Find pair")]
        FindPair =21,
        [Display(Name = "Repeat and remember")]
        RepeatAndRemember =22,
        [Display(Name ="Say what can be done")]
        SayWhatCanBeDone = 23,
    }
}
